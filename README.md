# Development Notes
The main objective of the Gilded Rose kata was completed in commit **chore: Remove unused files (ab7bdf0)**.  
From that point onward, subsequent changes focus solely on **refactoring**, **improving readability**, and **exploring design alternatives** without modifying the expected behavior.

# Repository objetive
This repository contains my personal implementation of the Gilded Rose Kata, focused on practicing disciplined refactoring techniques, incremental design, and safe change strategies.
The goal is to work with legacy code in a way that preserves existing behavior while improving structure, clarity, and extensibility.

## Technical Approach
This kata is an opportunity to demonstrate how I approach evolving legacy codebases while maintaining confidence in behavior and enabling future change. My focus in this implementation includes:
- Refactoring with Parallel Change: introducing new structures alongside existing ones, migrating behavior safely, and removing old code only once the new design is fully validated.
- Test-Driven Development (TDD): using small, incremental steps to guide design decisions and ensure correctness.
- Characterization Tests: capturing the current behavior of the legacy system to create a safety net before refactoring.
- Baby Steps: making minimal, reversible changes to keep the system always working and reduce cognitive load.
- Design for Extensibility: moving from conditional-heavy logic toward composable, testable units that make adding new item types straightforward.
- Separation of Concerns: isolating business rules from orchestration logic to improve readability and maintainability.
- Incremental Improvement: preferring continuous, small refactors over large, risky rewrites.

This approach mirrors how I like to work in real projects: improving codebases sustainably, keeping risk low, and ensuring that every change is supported by tests and clear intent.

# Gilded Rose Requirements
- [Requirements](GildedRoseRequirements.md)

# Original repository and credits
All credit for [Emily Bache](https://github.com/emilybache).

Original kata repository: [GildedRose-Refactoring-Kata, by Emily Bache](https://github.com/emilybache/GildedRose-Refactoring-Kata)