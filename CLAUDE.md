# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Repo Is

A Three.js rebuild of **ShotDogGun** — a 3D toon-shaded arcade shooter originally made in Unity 2017. The entire game lives in a single file: `game.html`. The `Build/`, `index.html`, and `TemplateData/` files are the original Unity WebGL build and are not the active game. The original Unity source is in `Cannon3/`.

## Running Locally

Requires a local HTTP server (not `file://`):

```bash
python3 -m http.server 8080
```

Then open `http://localhost:8080/game.html`.

## Game Design

**Concept**: A double-barrelled hot dog bun is the player's cannon. Sausages are the ammunition. Burgers are the enemies.

**Controls**: Mouse aims the cannon. Click fires.

**Firing cycle**:
- Shots 1 & 2 fire one sausage each from Barrel1 then Barrel2. Each barrel's sausage visually disappears when fired.
- After 2 shots the bun is empty — "RELOAD!!!" is shown. The 3rd click reloads both barrels and resets the perfect streak.

**Enemies**: Two off-screen launchers (`launcherDefs`) fire burgers at random intervals toward the player. Burgers auto-destroy after 8 seconds if not hit.

**Scoring**:
- Sausage hits burger → +1 score, burger explodes into ragdoll parts, `perfect` counter increments
- `perfect` reaches 2 (two hits without reloading) → +1 bonus life, "PERFECT" flash, perfect resets
- Intact burger hits the floor → −1 life (broken debris hitting the floor has no penalty)
- Lives reach 0 → GAME OVER screen with PLAY AGAIN button

## Architecture (`game.html`)

Everything is in one `<script type="module">` block. Key sections in order:

- **Constants** — speeds, gravity, intervals
- **Scene setup** — renderer, teal sky (`#5BBFBF`), powder blue floor (`#A0D4E8`), toon materials, directional light
- **Cannon** — `cannon` (Three.js Group) holds `bunBase` (BoxGeometry) and `barrel1`/`barrel2` (CapsuleGeometry). The whole group rotates to aim.
- **Launchers** — `launcherDefs` array (two positions), `launcherTimers` drive `launchBurger(idx)`
- **Burger factory** — `makeBurger()` returns a Group with four child meshes: `topBun`, `patty`, `lettuce`, `botBun`
- **Firing** — `fireSausage(barrelMesh)` spawns a projectile from the barrel's world position, aimed via `getAimDirection()` (ray cast 18 units from camera)
- **Game state arrays** — `projectiles`, `burgers`, `debris` — all updated and culled each frame in `tick()`
- **Collision** — simple sphere distance checks (`sphereHit`) between projectiles and burger groups
- **Explode** — `explodeBurger()` detaches burger child meshes via `scene.attach()`, gives each a random velocity and angular velocity, moves them to the `debris` array
- **UI** — HTML overlay (`#ui`) with Fredoka One font; score/lives divs updated directly; `#message` div for RELOAD!!!/PERFECT; `#gameover` shown on death

## Visual Style

- `MeshToonMaterial` throughout — no textures, flat cel shading
- Sausages: `#E07070` · Bun: `#C8A060` · Patty: `#B83030` · Lettuce: `#88C840`
- Sky: `#5BBFBF` · Floor: `#A0D4E8`
- Font: Fredoka One (Google Fonts) — matches the rounded feel of the original Albus font
- PLAY AGAIN button: `#E8B840` golden yellow
