# Instructions for the AI delivery agent: eShopOnWeb

Put this file at `.github/copilot-instructions.md` in the eShopOnWeb repository, on the branch the agent works against, and commit it.
The text between the `agent-skill` markers is written by the console from the .NET skill. Everything outside the markers is yours.

## What this repository is
- A .NET 8 solution (`net8.0`, SDK `8.0.x` from `global.json`) in Clean Architecture layers:
  - `src/ApplicationCore`: domain and business logic. It references only `BlazorShared`. It must never reference Infrastructure, Web or PublicApi.
  - `src/Infrastructure`: EF Core, Identity and data access. References ApplicationCore.
  - `src/Web`: the MVC / Razor site. References ApplicationCore, Infrastructure, BlazorAdmin and BlazorShared.
  - `src/PublicApi`: the HTTP API. References ApplicationCore and Infrastructure.
  - `src/BlazorAdmin`, `src/BlazorShared`: the admin client and its shared models.
- Tests are in `tests/`: `UnitTests`, `IntegrationTests`, `FunctionalTests`, `PublicApiIntegrationTests`.

## Package versions: read this before changing any dependency
- Central package management is on. Every package version is set in `Directory.Packages.props` at the repository root.
- A `PackageReference` in a `.csproj` has **no** `Version`. To upgrade a package, change its `PackageVersion` in `Directory.Packages.props`. Never add `Version=` to a `PackageReference` (it breaks the restore with NU1008).
- Some versions are properties in that file (`AspNetVersion`, `SystemExtensionVersion`, `EntityFramworkCoreVersion`, `VSCodeGeneratorVersion`). Change the property once, not each line.
- Use `VersionOverride` only when one project truly needs a different version, and say why in a comment.
- For a security advisory, move to the smallest version that fixes it (a patch bump where one exists). Do not jump a major version and do not change other packages in the same ticket.
- After a version change, look for code that uses the package and make sure it still compiles. A patch bump should need no code change.

## Code conventions
- C# on .NET 8. Follow the surrounding file: naming, nullable annotations, `using` style.
- PascalCase for types and members, `_camelCase` for private fields. `async`/`await` end to end. Constructor injection.
- Use the existing patterns: `Ardalis.Specification` for queries, `Ardalis.GuardClauses` for argument checks.
- JSON in ApplicationCore goes through the `ToJson` / `FromJson` helpers in `src/ApplicationCore/Extensions/JsonExtensions.cs` (namespace `Microsoft.eShopWeb`). Do not create new `JsonSerializerOptions` for the same job.
- No secrets, tokens or connection strings in code or config.

## Tests
- Unit tests live in `tests/UnitTests`, use **xUnit** and **NSubstitute**, and mirror the `src` folder structure (for example `tests/UnitTests/ApplicationCore/Extensions/` tests `src/ApplicationCore/Extensions/`).
- Use `[Fact]` and `[Theory]` with `[InlineData]`. Name a test for the behaviour it checks.
- Add or update a unit test with every behaviour change. Cover the normal case, an edge case, invalid input and the error path.
- For a dependency upgrade, add unit tests for the ApplicationCore code that uses that package if none exist yet.
- Do not add test frameworks or packages. Do not change `IntegrationTests`, `FunctionalTests` or `PublicApiIntegrationTests` unless the ticket says so.

## What you cannot run
- You cannot run `dotnet`. The pipeline runs `dotnet restore`, `dotnet build` and the unit tests for you after you finish.
- So make the change correct before you stop: it must compile, add no new warnings and leave no unused `using` lines.

## Never change
- Anything under `.github/`, `appsettings.Production.json`, `.env`, `global.json` or the `TargetFramework`.
- Files the ticket does not need. Keep the change as small as the ticket allows.
- Do not push, open a pull request or run deploy or publish commands. The pipeline does that after review.

## Reports
- If you write a report or notes, put them under `docs/ai-reports/`.
