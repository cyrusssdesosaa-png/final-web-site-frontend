using System.Collections.Generic;

namespace WallyWombatsPublic_MVC.Models;

/// <summary>
/// View-model for the "pick your location" picker rendered at `/` (root).
/// Replaces the single-store landing with a Kids-Empire-style multi-location grid.
///
/// Inherits from HomeModel so Jerickson's shared layout partials (which search
/// /Views/Home/ first for anything rendered under the Home controller) continue
/// to receive a HomeModel-compatible instance — specifically _PartialViewFAQ
/// which iterates `Model.FAQViewModel`.
/// </summary>
public class WelcomeViewModel : HomeModel
{
}
