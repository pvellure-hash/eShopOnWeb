# CLAUDE-20 Implementation Thinking

## Implementation approach
The correction is limited to the integrity metadata for the two 4.0.0 production CDN assets and the required reports.

## Changes by file
The force-app changes are limited to the two production script references:

| File | Change |
| --- | --- |
| `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml` | Replaced the stale integrity hash with the SHA-384 value for jquery-validation-unobtrusive 4.0.0. |
| `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml` | Replaced the stale integrity hash with the SHA-384 value for jquery-validation-unobtrusive 4.0.0. |

The required reports were updated:

| File | Change |
| --- | --- |
| `docs/ai-reports/CLAUDE-20.md` | Recorded the root cause, correction, and library review. |
| `docs/ai-reports/CLAUDE-20-pr.md` | Updated the pull request description and validation status. |
| `docs/ai-reports/CLAUDE-20-jira.md` | Updated the ticket comment and retained `<PR link>`. |
| `docs/ai-reports/CLAUDE-20-solution-thinking.md` | Recorded the revised root cause and correction. |
| `docs/ai-reports/CLAUDE-20-implementation-thinking.md` | Recorded the changed files and verification status. |

## Reviewed call sites
Both script partials use the 4.0.0 CDN path and matching integrity value; neither calls unobtrusive-validation APIs directly. Their Development/Docker paths and local fallbacks remain unchanged. The repository search found LibMan already on 4.0.0 and no other outdated CDN references.

## Verification and outstanding items
No unit tests were added because only external asset metadata changed and there is no application logic to exercise. Local .NET tests were not run because repository instructions prohibit `dotnet` commands. Pipeline browser integrity validation and the configured unit suite remain outstanding.
