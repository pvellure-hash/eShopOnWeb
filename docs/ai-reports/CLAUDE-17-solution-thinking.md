# CLAUDE-17 Solution Thinking

## Requirement classification
This is a bug fix for a vulnerable package version, not a feature request.

## Acceptance criteria
Microsoft.AspNetCore.Components.WebAssembly.Server must resolve to 10.0.13 or higher wherever declared or pinned, no other package may change, existing Blazor hosting behavior must remain intact, and pipeline build, unit tests, and vulnerability scan must pass.

## Assumptions
Central package management is authoritative. A direct 10.0.13 entry for the affected package is sufficient; changing the shared AspNetVersion property would incorrectly upgrade several unrelated ASP.NET packages.

## Root cause
The affected package entry inherited AspNetVersion 8.0.2. The Web project referenced the package centrally, making 8.0.2 resolve for the Web host.

## Planned correction
Replace only the affected central package entry with 10.0.13, retain the versionless project reference, remove legacy framework middleware extensions that fail to compile with 10.0.13, and document pipeline validation requirements.

## Result
Microsoft.AspNetCore.Components.WebAssembly.Server is pinned explicitly at 10.0.13. The 10.0.13 build incompatibility was corrected by removing `UseWebAssemblyDebugging` and `UseBlazorFrameworkFiles`; static files and fallback routing remain enabled.
