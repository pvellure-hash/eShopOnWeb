# CLAUDE-17 Solution Report

## Requirement and acceptance criteria
This is a dependency vulnerability bug fix. Upgrade Microsoft.AspNetCore.Components.WebAssembly.Server from 8.0.2 to 10.0.13 or higher for CVE-2026-96230 / GHSA-qjpx-jqm5-h2c4, with no other package changed.

## Root cause
The Web project declared Microsoft.AspNetCore.Components.WebAssembly.Server through central package management, and its package entry resolved the shared AspNetVersion value of 8.0.2. That made the vulnerable server package available to the Web host.

## Change made
Added an explicit 10.0.13 central PackageVersion entry for Microsoft.AspNetCore.Components.WebAssembly.Server. The shared AspNetVersion property remains 8.0.2, so no other ASP.NET package is upgraded by this ticket.

Corrected the 10.0.13 major-version call sites in `src/Web/Program.cs`: removed the no-longer-exposed `UseWebAssemblyDebugging()` and `UseBlazorFrameworkFiles()` middleware calls. Standard static-file and fallback middleware remain in place.

Self-correction: updated the startup call sites after pipeline validation showed that the 10.0.13 package no longer exposes the two legacy middleware extensions.

## Library upgrade review
- `Directory.Packages.props`: changed the Microsoft.AspNetCore.Components.WebAssembly.Server central package version from `$(AspNetVersion)` / 8.0.2 to 10.0.13.
- `src/Web/Web.csproj`: retained the existing versionless PackageReference; central package management resolves it at 10.0.13.
- `src/Web/Program.cs`: retained `builder.Services.AddServerSideBlazor()`, `app.UseStaticFiles()`, and `app.MapFallbackToFile("index.html")`. Removed `app.UseWebAssemblyDebugging()` and `app.UseBlazorFrameworkFiles()`, which are not exposed after the 10.0.13 package upgrade.
- Repository search found only the central package declaration and the Web project reference; no Docker, CI, script, documentation, project, or lock-file copy was found.

## Tests and validation
The package bump and startup compatibility correction affect dependency resolution and middleware registration. No focused unit test was added because the ticket is a package/API compatibility fix and repository instructions permit no local dotnet test run. Pipeline validation must restore/build/test the solution and run `dotnet list eShopOnWeb.sln package --vulnerable --include-transitive`.

## Files changed
- `Directory.Packages.props`
- `src/Web/Program.cs`
- `docs/ai-reports/CLAUDE-17.md`
- `docs/ai-reports/CLAUDE-17-pr.md`
- `docs/ai-reports/CLAUDE-17-jira.md`
- `docs/ai-reports/CLAUDE-17-solution-thinking.md`
- `docs/ai-reports/CLAUDE-17-implementation-thinking.md`

## Remaining work
No lock file is present to regenerate manually. Run `dotnet restore --force-evaluate` if restore metadata or assets need regeneration. The pipeline must confirm that CVE-2026-96230 and GHSA-qjpx-jqm5-h2c4 are not reported and that all configured unit tests pass.
