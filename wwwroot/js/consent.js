// First-party cookie choices. Google Consent Mode defaults are set in the layout
// before this file, so a later Google tag sees the stored choice.
(function () {
    var cookieKey = 'ww_cookie_consent';

    function readCookie(name) {
        var prefix = name + '=';
        var parts = document.cookie.split('; ');
        for (var i = 0; i < parts.length; i++) {
            if (parts[i].indexOf(prefix) === 0) {
                try {
                    return decodeURIComponent(parts[i].slice(prefix.length));
                } catch (e) {
                    return parts[i].slice(prefix.length);
                }
            }
        }
        return '';
    }

    function writeCookie(name, value, days) {
        var secure = location.protocol === 'https:' ? '; Secure' : '';
        var maxAge = Math.round(days * 24 * 60 * 60);
        document.cookie = name + '=' + encodeURIComponent(value) + '; Max-Age=' + maxAge + '; Path=/; SameSite=Lax' + secure;
    }

    function parseChoice(raw) {
        if (raw === 'accepted') return { analytics: true, marketing: true, media: true, set: true };
        if (raw === 'declined') return { analytics: false, marketing: false, media: false, set: true };
        var match = /^v2:([01])\.([01])\.([01])$/.exec(raw || '');
        if (!match) return { analytics: false, marketing: false, media: false, set: false };
        return { analytics: match[1] === '1', marketing: match[2] === '1', media: match[3] === '1', set: true };
    }

    function encodeChoice(choice) {
        return 'v2:' + (choice.analytics ? '1' : '0') + '.' + (choice.marketing ? '1' : '0') + '.' + (choice.media ? '1' : '0');
    }

    function gtagUpdate(choice) {
        if (typeof window.gtag !== 'function') return;
        var on = function (allowed) { return allowed ? 'granted' : 'denied'; };
        window.gtag('consent', 'update', {
            analytics_storage: on(choice.analytics),
            ad_storage: on(choice.marketing),
            ad_user_data: on(choice.marketing),
            ad_personalization: on(choice.marketing),
            personalization_storage: on(choice.marketing),
            functionality_storage: on(choice.media)
        });
    }

    function current() {
        return parseChoice(readCookie(cookieKey));
    }

    function applyEmbeds(allowMedia) {
        document.querySelectorAll('[data-ww-embed="media"]').forEach(function (box) {
            var frame = box.querySelector('iframe[data-src]');
            var note = box.querySelector('.ww-embed-note');
            if (!frame) return;
            if (allowMedia) {
                if (!frame.getAttribute('src')) frame.setAttribute('src', frame.getAttribute('data-src') || '');
                frame.hidden = false;
                if (note) note.hidden = true;
            } else {
                frame.removeAttribute('src');
                frame.hidden = true;
                if (note) note.hidden = false;
            }
        });
    }

    function setOpen(open) {
        var banner = document.getElementById('wwCookie');
        document.documentElement.classList.toggle('ww-cookie-open', open);
        document.documentElement.classList.toggle('ww-cookie-pending', open && !current().set);
        if (banner) banner.classList.toggle('is-open', open);
        if (open) syncChecks();
    }

    function syncChecks() {
        var choice = current();
        document.querySelectorAll('[data-consent-cat]').forEach(function (box) {
            var cat = box.getAttribute('data-consent-cat');
            box.checked = !!choice[cat];
        });
    }

    function readChecks() {
        var choice = { analytics: false, marketing: false, media: false, set: true };
        document.querySelectorAll('[data-consent-cat]').forEach(function (box) {
            choice[box.getAttribute('data-consent-cat')] = box.checked;
        });
        return choice;
    }

    function save(choice) {
        writeCookie(cookieKey, encodeChoice(choice), 365);
        writeCookie('ww_opt', '', 0);
        gtagUpdate(choice);
        applyEmbeds(choice.media);
        setOpen(false);
        document.dispatchEvent(new CustomEvent('ww-consent'));
    }

    function openSettings() {
        var prefs = document.getElementById('wwCookiePrefs');
        if (prefs) prefs.hidden = false;
        var saveBtn = document.getElementById('wwCookieSave');
        if (saveBtn) saveBtn.hidden = false;
        var closeBtn = document.getElementById('wwCookieClose');
        if (closeBtn) closeBtn.hidden = !current().set;
        setOpen(true);
    }

    window.wwConsent = {
        allows: function (cat) {
            var choice = current();
            return !!(choice.set && choice[cat]);
        },
        open: openSettings
    };

    document.addEventListener('DOMContentLoaded', function () {
        var choice = current();
        if (choice.set) gtagUpdate(choice);
        applyEmbeds(choice.media);

        var banner = document.getElementById('wwCookie');
        var closeBtn = document.getElementById('wwCookieClose');
        if (closeBtn) closeBtn.hidden = !choice.set;
        if (banner && document.documentElement.classList.contains('ww-cookie-pending')) {
            banner.classList.add('is-open');
        }
        document.addEventListener('keydown', function (event) {
            if (event.key === 'Escape' && current().set) setOpen(false);
        });

        document.addEventListener('click', function (event) {
            var settings = event.target.closest('[data-cookie-settings]');
            if (settings) {
                event.preventDefault();
                openSettings();
                return;
            }
            if (!banner) return;
            var button = event.target.closest('[data-cookie-choice]');
            if (!button || !banner.contains(button)) return;
            var action = button.getAttribute('data-cookie-choice');
            if (action === 'all') {
                save({ analytics: true, marketing: true, media: true, set: true });
            } else if (action === 'none') {
                save({ analytics: false, marketing: false, media: false, set: true });
            } else if (action === 'customize') {
                var prefs = document.getElementById('wwCookiePrefs');
                if (prefs) prefs.hidden = false;
                var saveBtn = document.getElementById('wwCookieSave');
                if (saveBtn) saveBtn.hidden = false;
                syncChecks();
            } else if (action === 'save') {
                save(readChecks());
            } else if (action === 'close' && current().set) {
                setOpen(false);
            }
        });
    });
})();
