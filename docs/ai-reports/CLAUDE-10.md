# CLAUDE-10 Solution Report

## Requirement and acceptance criteria
This is a dependency vulnerability bug fix. Upgrade jquery-validation from 1.19.5 to the stable patched release 1.21.0 for CVE-2025-3573 / GHSA-rrj2-ph5q-jxw2, remove references to vulnerable CDN releases, and keep client-side form validation loading in the Web and Identity areas.

## Root cause
`src/Web/libman.json` declared jquery-validation 1.19.5. Both validation partials used older CDN versions in non-development environments (1.14.0 in the shared partial and 1.17.0 in Identity), while their local references did not match the LibMan destination. Thus affected pages could load a vulnerable release rather than the configured package.

## Change made
Updated the LibMan version to 1.21.0 and changed both validation partials to use the configured local `wwwroot/lib/jquery-validate/` assets in all environments. This removes old jquery-validation CDN URLs and aligns the development and production paths with the existing LibMan destination. The Identity partial's local/fallback jquery-validation-unobtrusive paths were also aligned with its existing LibMan destination; its package version and CDN release were not changed.

## Library upgrade review
- `src/Web/libman.json`: changed jquery-validation from 1.19.5 to 1.21.0; the existing selection of the minified and unminified scripts remains.
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`: changed both environment paths to the configured library destination and removed the 1.14.0 CDN source.
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`: changed both environment paths to the configured library destination and removed the 1.17.0 CDN source.
- Repository search found no direct `.validate()` calls or other jquery-validation references beyond the manifest and these two partials. The checkout did not contain physical vendor files under `wwwroot/lib`; LibMan configuration is the checked-in source for those assets.
- The shared partial is included by `Pages/Admin/EditCatalogItem.cshtml`, `Views/Manage/EnableAuthenticator.cshtml`, `ChangePassword.cshtml`, `TwoFactorAuthentication.cshtml`, `SetPassword.cshtml`, `MyAccount.cshtml`, and `Views/Account/LoginWith2fa.cshtml`. The Identity partial is included by `Areas/Identity/Pages/Account/Login.cshtml` and `Register.cshtml`. Their data-annotation and validation-tag-helper usage was reviewed; no custom jquery-validation API usage needs adjustment.
- `Pages/Basket/Index.cshtml` and `Pages/Basket/Checkout.cshtml` show validation summaries but do not include either validation partial; their existing server-side validation behavior is unchanged.
- jquery-validation-unobtrusive package declarations and CDN versions were left unchanged as requested.

## Tests and validation
No JavaScript test harness exists in this repository, and this dependency/asset-reference change adds no application JavaScript behavior to unit-test. No tests were added. Local .NET restore, build, and tests were not run because `.github/copilot-instructions.md` prohibits `dotnet` commands; pipeline validation must run the configured tests and vulnerability scan. The checkout had no vendor payload to restore locally, so the build pipeline must also confirm that the existing LibraryManager build tooling restores the configured assets.

## Files changed
- `src/Web/libman.json`
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`
- `docs/ai-reports/CLAUDE-10.md`
- `docs/ai-reports/CLAUDE-10-pr.md`
- `docs/ai-reports/CLAUDE-10-jira.md`
- `docs/ai-reports/CLAUDE-10-solution-thinking.md`
- `docs/ai-reports/CLAUDE-10-implementation-thinking.md`

## Remaining work
Pipeline validation must confirm the restored LibMan assets resolve at the configured paths, all configured tests pass, and the vulnerability scan no longer reports CVE-2025-3573 / GHSA-rrj2-ph5q-jxw2. No NuGet lock file applies; the LibraryManager asset restore remains to be verified by the pipeline.
