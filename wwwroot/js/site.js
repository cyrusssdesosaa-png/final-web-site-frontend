// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(document).on("scroll", function () {
//    var pageTop = $(document).scrollTop();
//    var pageBottom = pageTop + $(window).height();
//    var tags = $(".tag");

//    for (var i = 0; i < tags.length; i++) {
//        var tag = tags[i];

//        if ($(tag).position().top < pageBottom) {
//            $(tag).addClass("visible");
//        } else {
//            $(tag).removeClass("visible");
//        }
//    }
//});


if (window.innerWidth < 768) {
    [].slice.call(document.querySelectorAll('[data-bss-disabled-mobile]')).forEach(function (elem) {
        elem.classList.remove('animated');
        elem.removeAttribute('data-bss-hover-animate');
        elem.removeAttribute('data-aos');
        elem.removeAttribute('data-bss-parallax-bg');
        elem.removeAttribute('data-bss-scroll-zoom');
    });
}

document.addEventListener('DOMContentLoaded', function () {
    var navType = performance.getEntriesByType && performance.getEntriesByType('navigation')[0];
    if (navType && navType.type === 'reload') {
        if (location.hash) history.replaceState(null, '', location.pathname + location.search);
        window.scrollTo(0, 0);
        window.addEventListener('load', function () { window.scrollTo(0, 0); });
    }

    if ('AOS' in window) {
        AOS.init();
    }

    var cookieKey = 'ww_cookie_consent';
    var optKey = 'ww_opt';
    var overlay = document.getElementById('wwCookie');
    var onPrivacy = /privacy-policy/i.test(location.pathname);

    function readCookie(name) {
        var prefix = name + '=';
        var parts = document.cookie.split('; ');
        for (var i = 0; i < parts.length; i++) {
            if (parts[i].indexOf(prefix) === 0) {
                return decodeURIComponent(parts[i].slice(prefix.length));
            }
        }
        return '';
    }

    function writeCookie(name, value, days) {
        var expires = new Date();
        expires.setTime(expires.getTime() + days * 24 * 60 * 60 * 1000);
        document.cookie = name + '=' + encodeURIComponent(value) + '; expires=' + expires.toUTCString() + '; path=/; SameSite=Lax';
    }

    function closeCookiePopup() {
        document.documentElement.classList.remove('ww-cookie-pending');
    }

    function applyOptimization(accepted) {
        if (accepted) {
            writeCookie(optKey, '1', 365);
        } else {
            writeCookie(optKey, '', -1);
        }
    }

    if (overlay && !onPrivacy && !readCookie(cookieKey)) {
        document.documentElement.classList.add('ww-cookie-pending');
    }

    if (overlay) {
        overlay.addEventListener('click', function (event) {
            var choice = event.target.getAttribute('data-cookie-choice');
            if (!choice) return;
            writeCookie(cookieKey, choice, 365);
            applyOptimization(choice === 'accepted');
            closeCookiePopup();
        });
    }

    document.querySelectorAll('[data-pick]').forEach(function (pick) {
        var key = pick.getAttribute('data-pick');
        var board = document.querySelector('[data-board="' + key + '"]');
        if (!board) return;

        function current(attr, fallback) {
            var on = pick.querySelector('.ww-pick-btn.is-on[' + attr + ']');
            return on ? on.getAttribute(attr) : fallback;
        }

        function apply() {
            var locBtn = pick.querySelector('.ww-pick-btn.is-on[data-loc]');
            var loc = locBtn ? locBtn.getAttribute('data-loc') : '';
            var allowed = (locBtn && locBtn.getAttribute('data-days')) ? locBtn.getAttribute('data-days').split(',').filter(Boolean) : [];
            pick.querySelectorAll('.ww-pick-btn[data-day]').forEach(function (btn) {
                var ok = !allowed.length || allowed.indexOf(btn.getAttribute('data-day')) !== -1;
                btn.style.display = ok ? '' : 'none';
                if (!ok) btn.classList.remove('is-on');
            });
            if (allowed.length && !pick.querySelector('.ww-pick-btn.is-on[data-day]')) {
                var firstDay = pick.querySelector('.ww-pick-btn[data-day="' + allowed[0] + '"]');
                if (firstDay) firstDay.classList.add('is-on');
            }
            var dayBtn = pick.querySelector('.ww-pick-btn[data-day]');
            var day = dayBtn ? current('data-day', allowed[0] || '') : null;
            board.querySelectorAll('.ww-price-card').forEach(function (card) {
                var locOk = !loc || card.getAttribute('data-loc') === loc;
                var cardDay = card.getAttribute('data-day');
                var dayOk = !day || !cardDay || cardDay === day;
                card.style.display = locOk && dayOk ? '' : 'none';
            });
            if (key === 'rates') {
                var specials = document.getElementById('wwSpecials');
                if (specials) {
                    var cards = specials.querySelectorAll('[data-special-loc]');
                    var any = false;
                    cards.forEach(function (card) {
                        var on = !loc || card.getAttribute('data-special-loc') === loc;
                        card.style.display = on ? '' : 'none';
                        if (on) any = true;
                    });
                    if (any) specials.classList.add('is-in');
                    else specials.classList.remove('is-in');
                }
            }
        }

        pick.addEventListener('click', function (event) {
            var btn = event.target.closest('.ww-pick-btn');
            if (!btn) return;
            var group = btn.hasAttribute('data-loc') ? 'data-loc' : 'data-day';
            pick.querySelectorAll('.ww-pick-btn[' + group + ']').forEach(function (el) {
                el.classList.toggle('is-on', el === btn);
            });
            apply();
            if (btn.hasAttribute('data-loc')) {
                var name = (btn.textContent || '').trim();
                var label = document.querySelector('[data-loc-label]');
                if (label && name) label.textContent = 'Prices for ' + name;
            }
        });

        apply();
    });

    var wwScrollTimer = 0;
    function wwScrollToY(top) {
        var start = window.scrollY || document.documentElement.scrollTop || 0;
        var dest = Math.max(0, top);
        var dist = dest - start;
        if (Math.abs(dist) < 2) {
            window.scrollTo(0, dest);
            return;
        }
        var duration = Math.min(1100, Math.max(520, Math.abs(dist) * 0.42));
        var started = performance.now();
        document.documentElement.classList.add('ww-js-scroll');
        window.cancelAnimationFrame(wwScrollTimer);
        function tick(now) {
            var p = Math.min(1, (now - started) / duration);
            var eased = 1 - Math.pow(1 - p, 3);
            window.scrollTo(0, start + dist * eased);
            if (p < 1) {
                wwScrollTimer = window.requestAnimationFrame(tick);
                return;
            }
            document.documentElement.classList.remove('ww-js-scroll');
        }
        wwScrollTimer = window.requestAnimationFrame(tick);
    }

    function wwChromeOffset() {
        var raw = getComputedStyle(document.documentElement).getPropertyValue('--ww-chrome');
        var n = parseFloat(raw);
        return isNaN(n) ? 138 : n;
    }

    function wwScrollToTarget(id) {
        if (!id || id === 'home' || id === 'top') {
            wwScrollToY(0);
            return;
        }
        var el = document.getElementById(id);
        if (!el) return;
        wwScrollToY(el.getBoundingClientRect().top + (window.scrollY || 0) - wwChromeOffset() + 2);
    }

    function wwOnHome() {
        return !!document.querySelector('.ww-hero');
    }

    var nav = document.getElementById('wwTopNav');
    if (nav && wwOnHome()) {
        var spy = [
            { id: 'home', el: document.querySelector('.ww-hero') },
            { id: 'crew', el: document.getElementById('crew') },
            { id: 'playground', el: document.getElementById('playground') },
            { id: 'arcade', el: document.getElementById('arcade') },
            { id: 'birthdays', el: document.getElementById('birthdays') },
            { id: 'locations', el: document.getElementById('locations') },
            { id: 'shorts', el: document.getElementById('shorts') },
            { id: 'series', el: document.getElementById('series') },
            { id: 'spotify', el: document.getElementById('spotify') },
            { id: 'contact', el: document.getElementById('contact') }
        ];
        function markNav() {
            var line = 150;
            var current = 'home';
            spy.forEach(function (item) {
                if (!item.el) return;
                if (item.el.getBoundingClientRect().top <= line) current = item.id;
            });
            nav.querySelectorAll('[data-nav]').forEach(function (link) {
                link.classList.toggle('is-on', link.getAttribute('data-nav') === current);
            });
        }
        markNav();
        window.addEventListener('scroll', markNav, { passive: true });

        nav.querySelectorAll('a[data-nav]').forEach(function (link) {
            link.addEventListener('click', function (event) {
                if (!wwOnHome()) return;
                event.preventDefault();
                var id = link.getAttribute('data-nav') || 'home';
                wwScrollToTarget(id);
                if (history.replaceState) {
                    history.replaceState(null, '', id === 'home' ? location.pathname : '#' + id);
                }
                nav.classList.remove('open');
                var toggle = document.querySelector('.ww-topbar-toggle');
                if (toggle) {
                    toggle.classList.remove('open');
                    toggle.setAttribute('aria-expanded', 'false');
                }
            });
        });
    }

    document.querySelectorAll('a[href*="#"]').forEach(function (link) {
        if (link.closest('#wwTopNav')) return;
        link.addEventListener('click', function (event) {
            if (!wwOnHome()) return;
            var id = (link.getAttribute('href') || '').split('#')[1] || '';
            if (!id) return;
            if (id !== 'home' && !document.getElementById(id)) return;
            event.preventDefault();
            wwScrollToTarget(id);
        });
    });

    var toTop = document.getElementById('wwToTop');
    if (toTop) {
        function showToTop() {
            toTop.classList.toggle('is-in', (window.scrollY || 0) > 420);
        }
        showToTop();
        window.addEventListener('scroll', showToTop, { passive: true });
        toTop.addEventListener('click', function () {
            wwScrollToY(0);
            if (wwOnHome() && history.replaceState) {
                history.replaceState(null, '', location.pathname);
            }
        });
    }

    var story = document.getElementById('wwStoryVideo');
    if (story) {
        var storyDone = false;
        story.addEventListener('ended', function () {
            storyDone = true;
            story.pause();
        });
        if ('IntersectionObserver' in window) {
            var storyWatch = new IntersectionObserver(function (entries) {
                entries.forEach(function (entry) {
                    if (!entry.isIntersecting) {
                        story.pause();
                        return;
                    }
                    if (storyDone) return;
                    var playTry = story.play();
                    if (playTry && playTry.catch) playTry.catch(function () {});
                });
            }, { threshold: 0.4, rootMargin: '-80px 0px -40px 0px' });
            storyWatch.observe(story);
        }
    }

    var onPhone = /Android|iPhone|iPad|iPod/i.test(navigator.userAgent);
    document.querySelectorAll('[data-app-link], #shorts .ww-center a.ww-btn, #series .ww-center a.ww-btn').forEach(function (link) {
        if (!onPhone) link.setAttribute('target', '_blank');
    });

    if (document.querySelector('.tiktok-embed')) {
        if (!document.querySelector('script[src*="tiktok.com/embed.js"]')) {
            var tiktokScript = document.createElement('script');
            tiktokScript.src = 'https://www.tiktok.com/embed.js';
            tiktokScript.async = true;
            document.body.appendChild(tiktokScript);
        }
    }

    document.querySelectorAll('[data-watch-tabs]').forEach(function (pick) {
        var section = pick.closest('section');
        if (!section) return;
        pick.querySelectorAll('[data-watch-tab]').forEach(function (tab) {
            tab.addEventListener('click', function () {
                var which = tab.getAttribute('data-watch-tab');
                pick.querySelectorAll('[data-watch-tab]').forEach(function (btn) {
                    btn.classList.toggle('is-on', btn === tab);
                });
                section.querySelectorAll('[data-watch-panel]').forEach(function (panel) {
                    var on = panel.getAttribute('data-watch-panel') === which;
                    panel.classList.toggle('is-on', on);
                    if (on) {
                        panel.removeAttribute('hidden');
                        wakeWatchPanel(panel);
                    } else {
                        panel.setAttribute('hidden', '');
                    }
                });
            });
        });
    });

    document.querySelectorAll('[data-yt-drag]').forEach(function (scroller) {
            var shortsRow = !!scroller.closest('.ww-shorts-trio');
            var active = false;
            var dragging = false;
            var skipClick = false;
            var startX = 0;
            var startLeft = 0;
            var pointerId = null;

            function cards() {
                return Array.prototype.slice.call(scroller.querySelectorAll('.ww-yt-card'));
            }

            function markOn() {
                if (!shortsRow) return;
                var list = cards();
                if (!list.length) return;
                var left = scroller.scrollLeft;
                var best = 0;
                var bestDist = Infinity;
                list.forEach(function (card, i) {
                    var dist = Math.abs(card.offsetLeft - left);
                    if (dist < bestDist) {
                        bestDist = dist;
                        best = i;
                    }
                });
                list.forEach(function (card, i) {
                    card.classList.toggle('is-on', i === best);
                });
                scroller.classList.add('is-ready');
            }

            function snapNearest() {
                var list = cards();
                if (!list.length) return;
                var left = scroller.scrollLeft;
                var best = list[0];
                var bestDist = Infinity;
                list.forEach(function (card) {
                    var dist = Math.abs(card.offsetLeft - left);
                    if (dist < bestDist) {
                        bestDist = dist;
                        best = card;
                    }
                });
                scroller.scrollTo({ left: best.offsetLeft, behavior: 'smooth' });
            }

            function onMove(event) {
                if (!active || event.pointerId !== pointerId) return;
                var dx = event.clientX - startX;
                if (!dragging && Math.abs(dx) > 6) {
                    dragging = true;
                    scroller.classList.add('is-dragging');
                }
                if (!dragging) return;
                event.preventDefault();
                scroller.scrollLeft = startLeft - dx;
                markOn();
            }

            function endDrag(event) {
                if (!active) return;
                if (event && event.pointerId != null && event.pointerId !== pointerId) return;
                document.removeEventListener('pointermove', onMove);
                document.removeEventListener('pointerup', endDrag);
                document.removeEventListener('pointercancel', endDrag);
                if (dragging) {
                    skipClick = true;
                    setTimeout(function () { skipClick = false; }, 140);
                    snapNearest();
                }
                active = false;
                dragging = false;
                pointerId = null;
                scroller.classList.remove('is-dragging');
                markOn();
            }

            scroller.addEventListener('pointerdown', function (event) {
                if (event.pointerType === 'touch' || event.button !== 0) return;
                if (event.target.closest('a.ww-btn')) return;
                active = true;
                dragging = false;
                pointerId = event.pointerId;
                startX = event.clientX;
                startLeft = scroller.scrollLeft;
                document.addEventListener('pointermove', onMove);
                document.addEventListener('pointerup', endDrag);
                document.addEventListener('pointercancel', endDrag);
            });

            scroller.addEventListener('click', function (event) {
                if (!skipClick) return;
                event.preventDefault();
                event.stopPropagation();
                skipClick = false;
            }, true);

            scroller.addEventListener('scroll', function () {
                if (dragging) return;
                markOn();
            }, { passive: true });

            scroller.querySelectorAll('img, a, button').forEach(function (el) {
                el.setAttribute('draggable', 'false');
            });

            markOn();
        });

    var clipView = document.getElementById('wwClipView');
    if (clipView) {
        var clipFrame = clipView.querySelector('iframe');
        var clipWatch = document.getElementById('wwClipWatch');
        function closeClip() {
            clipView.hidden = true;
            clipFrame.src = '';
        }
        document.querySelectorAll('[data-yt-play]').forEach(function (btn) {
            btn.addEventListener('click', function () {
                var id = btn.getAttribute('data-yt-play') || '';
                if (!id) return;
                clipFrame.src = 'https://www.youtube.com/embed/' + id + '?autoplay=1&rel=0';
                if (clipWatch) clipWatch.href = btn.getAttribute('data-yt-watch') || ('https://www.youtube.com/watch?v=' + id);
                clipView.hidden = false;
            });
        });
        clipView.addEventListener('click', function (event) {
            if (event.target === clipView || event.target.closest('.ww-pic-view-close')) {
                closeClip();
            }
        });
        document.addEventListener('keydown', function (event) {
            if (event.key === 'Escape' && !clipView.hidden) closeClip();
        });
    }

    document.querySelectorAll('.ww-loc-menu').forEach(function (menu) {
        var toggle = menu.querySelector('.ww-loc-toggle');
        if (!toggle) return;
        toggle.addEventListener('click', function (event) {
            event.stopPropagation();
            var open = menu.classList.toggle('open');
            toggle.setAttribute('aria-expanded', open ? 'true' : 'false');
        });
    });
    document.addEventListener('click', function () {
        document.querySelectorAll('.ww-loc-menu.open').forEach(function (menu) {
            menu.classList.remove('open');
            var toggle = menu.querySelector('.ww-loc-toggle');
            if (toggle) toggle.setAttribute('aria-expanded', 'false');
        });
    });

    if (document.querySelector('.ww-book')) {
        window.scrollTo(0, 0);
        window.addEventListener('load', function () { window.scrollTo(0, 0); });
    }

    document.querySelectorAll('[data-photo-fade]').forEach(function (grid) {
        var figures = Array.prototype.slice.call(grid.querySelectorAll('figure[data-pool]'));
        if (!figures.length) return;

        figures.forEach(function (fig) {
            var first = fig.querySelector('img');
            if (!first) return;
            first.classList.add('is-on');
            if (fig.querySelectorAll('img').length > 1) return;
            var back = first.cloneNode(true);
            back.classList.remove('is-on');
            back.removeAttribute('alt');
            fig.appendChild(back);
        });

        function srcOf(img) {
            return img ? (img.getAttribute('src') || '') : '';
        }

        function usedSrcs() {
            var used = {};
            figures.forEach(function (fig) {
                var busy = fig.getAttribute('data-busy') === '1';
                fig.querySelectorAll('img').forEach(function (img) {
                    var src = srcOf(img);
                    if (src && (img.classList.contains('is-on') || busy)) used[src] = true;
                });
            });
            return used;
        }

        function swapOne(fig) {
            if (!fig || fig.getAttribute('data-busy') === '1') return false;
            var pool = (fig.getAttribute('data-pool') || '').split('|').filter(Boolean);
            var front = fig.querySelector('img.is-on');
            var back = fig.querySelector('img:not(.is-on)');
            if (!front || !back || pool.length < 2) return false;
            var used = usedSrcs();
            var current = srcOf(front);
            var choices = pool.filter(function (src) { return src && src !== current && !used[src]; });
            if (!choices.length) return false;
            var next = choices[Math.floor(Math.random() * choices.length)];
            fig.setAttribute('data-busy', '1');
            back.setAttribute('src', next);
            back.classList.add('is-on');
            front.classList.remove('is-on');
            window.setTimeout(function () {
                fig.removeAttribute('data-busy');
            }, 980);
            return true;
        }

        function shuffled() {
            var open = figures.slice();
            for (var i = open.length - 1; i > 0; i--) {
                var j = Math.floor(Math.random() * (i + 1));
                var hold = open[i];
                open[i] = open[j];
                open[j] = hold;
            }
            return open;
        }

        window.setInterval(function () {
            if (document.hidden) return;
            var order = shuffled();
            var first = null;
            for (var i = 0; i < order.length; i++) {
                if (swapOne(order[i])) {
                    first = order[i];
                    break;
                }
            }
            if (!first || Math.random() < 0.55) return;
            window.setTimeout(function () {
                if (document.hidden) return;
                for (var n = 0; n < order.length; n++) {
                    if (order[n] !== first && swapOne(order[n])) break;
                }
            }, 1200);
        }, 5600);
    });

    var gallery = document.getElementById('wwGallery');
    if (gallery) {
        var galImg = gallery.querySelector('img');
        var galList = [];
        var galIndex = 0;
        var galStartX = 0;
        var galMoved = false;

        function galShow(next) {
            if (!galList.length) return;
            galIndex = (next + galList.length) % galList.length;
            galImg.src = galList[galIndex].src;
            galImg.alt = galList[galIndex].alt || '';
            gallery.hidden = false;
        }

        function galClose() {
            gallery.hidden = true;
            galImg.src = '';
        }

        document.querySelectorAll('[data-gallery]').forEach(function (group) {
            group.addEventListener('click', function (event) {
                if (event.target.closest('a.ww-btn, .ww-book-show-bar, .ww-pic-view-close')) return;
                var clicked = event.target.closest('img');
                if (!clicked || !group.contains(clicked)) {
                    var card = event.target.closest('.ww-yt-card, .ww-book-pic, figure, article');
                    if (!card || !group.contains(card)) return;
                    clicked = card.querySelector('img');
                }
                if (!clicked) return;
                var frames = group.querySelectorAll('figure');
                var imgs = frames.length
                    ? Array.prototype.map.call(frames, function (fig) {
                        return fig.querySelector('img.is-on') || fig.querySelector('img');
                    }).filter(Boolean)
                    : Array.prototype.filter.call(group.querySelectorAll('img'), function (el) {
                        return !el.closest('a.ww-btn');
                    });
                var frame = clicked.closest('figure');
                if (frame && frames.length) clicked = frame.querySelector('img.is-on') || clicked;
                if (!imgs.length) return;
                event.preventDefault();
                event.stopPropagation();
                galList = Array.prototype.map.call(imgs, function (el) {
                    return { src: el.currentSrc || el.getAttribute('src') || el.src, alt: el.alt || '' };
                });
                galShow(Math.max(0, Array.prototype.indexOf.call(imgs, clicked)));
            }, true);
        });

        gallery.addEventListener('click', function (event) {
            if (galMoved) {
                galMoved = false;
                return;
            }
            if (event.target === gallery || event.target.closest('.ww-pic-view-close')) galClose();
        });
        var galPrev = gallery.querySelector('[data-gal-prev]');
        var galNext = gallery.querySelector('[data-gal-next]');
        if (galPrev) galPrev.addEventListener('click', function (event) { event.stopPropagation(); galShow(galIndex - 1); });
        if (galNext) galNext.addEventListener('click', function (event) { event.stopPropagation(); galShow(galIndex + 1); });
        gallery.addEventListener('touchstart', function (event) {
            galStartX = event.changedTouches[0].clientX;
        }, { passive: true });
        gallery.addEventListener('touchend', function (event) {
            var dx = event.changedTouches[0].clientX - galStartX;
            if (Math.abs(dx) < 40) return;
            galMoved = true;
            galShow(galIndex + (dx < 0 ? 1 : -1));
        }, { passive: true });
        document.addEventListener('keydown', function (event) {
            if (gallery.hidden) return;
            if (event.key === 'Escape') galClose();
            if (event.key === 'ArrowRight') galShow(galIndex + 1);
            if (event.key === 'ArrowLeft') galShow(galIndex - 1);
        });
    }

    var picView = document.getElementById('wwPicView');
    if (picView && !gallery) {
        var picImg = picView.querySelector('img');
        document.querySelectorAll('.ww-book-pic').forEach(function (btn) {
            btn.addEventListener('click', function () {
                picImg.src = btn.getAttribute('data-pic') || '';
                picView.hidden = false;
            });
        });
        picView.addEventListener('click', function (event) {
            if (event.target === picView || event.target.closest('.ww-pic-view-close')) {
                picView.hidden = true;
                picImg.src = '';
            }
        });
    }

    document.querySelectorAll('[data-book-show]').forEach(function (show) {
        var slides = Array.prototype.slice.call(show.querySelectorAll('.ww-book-slide'));
        var dots = Array.prototype.slice.call(show.querySelectorAll('[data-show-dot]'));
        if (!slides.length) return;
        var index = Math.max(0, slides.findIndex(function (slide) { return slide.classList.contains('is-on'); }));
        var timer = 0;

        function go(next) {
            index = (next + slides.length) % slides.length;
            slides.forEach(function (slide, i) { slide.classList.toggle('is-on', i === index); });
            dots.forEach(function (dot, i) { dot.classList.toggle('is-on', i === index); });
        }

        function play() {
            stop();
            if (slides.length < 2) return;
            timer = window.setInterval(function () { go(index + 1); }, 4500);
        }

        function stop() {
            if (timer) window.clearInterval(timer);
            timer = 0;
        }

        var prev = show.querySelector('[data-show-prev]');
        var next = show.querySelector('[data-show-next]');
        if (prev) prev.addEventListener('click', function () { go(index - 1); play(); });
        if (next) next.addEventListener('click', function () { go(index + 1); play(); });
        dots.forEach(function (dot, i) {
            dot.addEventListener('click', function () { go(i); play(); });
        });

        var startX = 0;
        var stage = show.querySelector('.ww-book-show-stage');
        if (stage) {
            stage.addEventListener('touchstart', function (event) {
                startX = event.changedTouches[0].clientX;
            }, { passive: true });
            stage.addEventListener('touchend', function (event) {
                var dx = event.changedTouches[0].clientX - startX;
                if (Math.abs(dx) < 40) return;
                go(index + (dx < 0 ? 1 : -1));
                play();
            }, { passive: true });
        }

        show.addEventListener('mouseenter', stop);
        show.addEventListener('mouseleave', play);
        play();
    });
}, false);