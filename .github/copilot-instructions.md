# GitHub Copilot Instructions for "Too Many Areas (Continued)" Mod Development

Welcome to the mod development environment for "Too Many Areas (Continued)"—a mod for RimWorld that enhances the user interface by providing an alternate layout for managing areas on the schedule and animal tabs. Whether you're contributing to the project or developing your own mods inspired by it, this guide will offer you structured insights into the mod's implementation, along with suggestions for utilizing GitHub Copilot for efficient coding. 

---

## Mod Overview and Purpose
"Too Many Areas (Continued)" is a UI enhancement mod originally created by mr_chimick and maintained by Mlie. It improves the look and feel of RimWorld's area management by offering an alternate layout that becomes active when there are more than 10 areas available. The mod is designed to be compatible with Fluffy's Area Unlocker, extending its usability by making area management seamless even with numerous areas.

### Key Features
- **Alternate Layout for Areas:** Automatically switches to an improved layout after 10 areas.
- **Dropdown Indicator:** Enhanced with a UI dropdown indicator for better navigation and selection.
- **Temporary Vanilla Interface:** Use the ALT key to temporarily revert to the vanilla interface.
  
### Integration
The mod is packaged for easy integration with RimWorld, focusing on UI improvements without altering core gameplay mechanics.

---

## Key Features and Systems
The mod employs the following systems to deliver its enhancements:

- **Dropdown Area Selector:** Custom dropdown UI components for user-friendly area selection.
- **Harmony Patching:** Uses Harmony to patch existing methods without modifying RimWorld's source code, ensuring compatibility with other mods.
- **Mod Settings:** Offers configurable settings for users to define the threshold for activating the alternate layout.

---

## Coding Patterns and Conventions
When working with the mod's code, adhere to the following conventions to ensure consistency and readability:

- **Naming Conventions:** Use PascalCase for all type names and method names. Use camelCase for local variables.
- **Code Organization:** Structure classes around specific functionalities, e.g., `DropdownAreaAllowedGUI` for dropdown UI elements.
- **Comments:** Use comments to describe patches and complex logic to maintain code clarity.
- **File Structure:** Organize files logically, separating GUI components, settings management, and patch files.

---

## XML Integration
XML files play a crucial role in setting up mod metadata and dependencies:

- **About.xml:** This file details the mod's description, author, and dependencies. Ensure the dependency on `brrainz.harmony` is defined for proper operation.
- **Manifest.xml:** Defines additional metadata and dependencies required for mod execution.

---

## Harmony Patching
Harness the power of Harmony to create non-destructive patches:

- **Prefix, Postfix, and Finalizer Usage:** Use these Harmony attributes to append or insert logic into RimWorld's methods. This allows for reversible and non-intrusive enhancements.
- **Type-Specific Patches:** Focus patches in files like `AreaAllowedGUI_DoAllowedAreaSelectors` to modify only the targeted GUI interactions.

---

## Suggestions for Copilot
GitHub Copilot can greatly expedite the development process. Here are some ways you can use Copilot effectively during mod development:

- **Code Suggestions:** Use Copilot to quickly generate method stubs and boilerplate code based on typical C# patterns.
- **Debug Assistance:** Leverage Copilot to suggest fixes for common C# and XML syntax errors.
- **UI Modifications:** Generate UI components by prompting Copilot with comments describing the desired layout, such as dropdown menus or dynamic buttons.
- **Patch Development:** Use Copilot to suggest Harmony patch templates by providing a brief description of the intended change.

By following these guidelines, your contributions to "Too Many Areas (Continued)" or similar projects can be more efficient and aligned with the existing codebase.

Happy Modding!

---

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

