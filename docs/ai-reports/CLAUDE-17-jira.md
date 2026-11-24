Updated Microsoft.AspNetCore.Components.WebAssembly.Server from 8.0.2 to 10.0.13 to address CVE-2026-96230 and GHSA-qjpx-jqm5-h2c4. The package is centrally pinned at 10.0.13. Removed the 10.0.13-incompatible `UseWebAssemblyDebugging` and `UseBlazorFrameworkFiles` startup calls while retaining static-file and fallback routing behavior.

No other package was upgraded, and no lock file or additional declaration was found. Local .NET commands were prohibited by repository instructions; pipeline validation must restore, build, run unit tests, and rerun the vulnerability scan. No source behavior changed, so no test was added.

PR: <PR link>
