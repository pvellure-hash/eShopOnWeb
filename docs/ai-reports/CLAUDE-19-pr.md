# Update jQuery to 4.1.0

## Summary
Updates the Web project's LibMan jQuery version from 3.6.3 to 4.1.0 and replaces the production layout's older jQuery 2.2.0 CDN reference with 4.1.0. No other library was changed.

## Validation
Reviewed all tracked jQuery declarations and the three listed script partials. The partials contain no direct jQuery API calls, and no removed jQuery API use was found in application JavaScript sources. No tests were added for the asset-version-only change. The ignored `wwwroot/lib/jquery` assets need restoration using `libman restore src\Web`; pipeline validation should then check build, tests, and page behavior with the existing Bootstrap and validation scripts.

## Files changed
`src/Web/libman.json`, `src/Web/Views/Shared/_Layout.cshtml`, and the required CLAUDE-19 reports under `docs/ai-reports/`.
