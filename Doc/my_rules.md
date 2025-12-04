---
trigger: always_on
alwaysApply: true
---
1. Load Context
   * Always load `docs/project_context.md` at the start of each session.
   * Begin the summary in chat with `[🧠 SESSION START]`.

2. Update Memory
   * Append or edit `docs/project_context.md` whenever progress or decisions occur.
   * End the chat summary with `[📝 MEMORY UPDATED]`.

3. File Structure
   * Use headers: `# Overview`, `# Goals`, `# Progress`, `# Pending`.
   * Keep history incremental; do not delete old context unless instructed.
   
4. Chat Process
   * Summarize the conversation using the above structure.
   * Keep it concise and focused on the most important points.
   * Use Russian language for your answers and all conversation, please.

