/*
    locations-promo.js — per-location promo popup helper.
    - Shows if ShowPromo=true on the Location AND user hasn't dismissed it in last 7 days.
    - Dismissal stored in localStorage keyed by location slug.
*/
(function () {
    'use strict';

    const promo = document.getElementById('loc-promo');
    if (!promo) return;

    const slug = promo.getAttribute('data-slug');
    const DISMISS_DAYS = 7;
    const key = 'ww.promo.dismissed.' + slug;

    const dismissedAt = parseInt(localStorage.getItem(key) || '0', 10);
    const stillValid  = dismissedAt > 0 &&
                        (Date.now() - dismissedAt) < DISMISS_DAYS * 86400000;

    if (!stillValid) {
        // Delay the popup so first-impression hero gets a chance.
        setTimeout(() => { promo.style.display = 'flex'; }, 1200);
    }

    promo.addEventListener('click', (e) => {
        // Close only if backdrop (not modal body) or close-button clicked
        if (e.target === promo || e.target.hasAttribute('data-promo-close')) {
            promo.style.display = 'none';
            localStorage.setItem(key, Date.now().toString());
        }
    });
})();
