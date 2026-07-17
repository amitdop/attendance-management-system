# 🤝 Contributing to Attendance Management System

Thank you for your interest in contributing! This document provides guidelines and instructions for contributing to the project.

---

## 📋 Table of Contents

1. [Code of Conduct](#code-of-conduct)
2. [Getting Started](#getting-started)
3. [Development Setup](#development-setup)
4. [Making Changes](#making-changes)
5. [Commit Guidelines](#commit-guidelines)
6. [Submitting Pull Requests](#submitting-pull-requests)
7. [Code Review Process](#code-review-process)
8. [Reporting Bugs](#reporting-bugs)
9. [Suggesting Enhancements](#suggesting-enhancements)

---

## 🤝 Code of Conduct

### Our Commitment
We are committed to providing a welcoming and inspiring community for all. Please read and adhere to our values:

- **Be Respectful** - Treat all contributors with respect
- **Be Inclusive** - Welcome diverse perspectives and backgrounds
- **Be Collaborative** - Work together toward common goals
- **Be Professional** - Maintain professional conduct in all interactions

### Unacceptable Behavior
- Harassment, discrimination, or offensive comments
- Insulting or belittling language
- Personal attacks or trolling
- Publishing others' private information

---

## 🚀 Getting Started

### 1. Fork the Repository
```bash
# Click the "Fork" button on GitHub
# This creates your own copy of the repository
```

### 2. Clone Your Fork
```bash
git clone https://github.com/YOUR_USERNAME/attendance-management-system.git
cd attendance-management-system
```

### 3. Add Upstream Remote
```bash
git remote add upstream https://github.com/amitdop/attendance-management-system.git
git fetch upstream
```

### 4. Create a Feature Branch
```bash
git checkout -b feature/your-feature-name
# OR
git checkout -b fix/bug-description
```

**Branch Naming Convention:**
- `feature/description` - New features
- `fix/description` - Bug fixes
- `docs/description` - Documentation updates
- `refactor/description` - Code refactoring
- `test/description` - Test additions

---

## 🛠️ Development Setup

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2+
- SQL Server 2016+
- Git

### Setup Steps

1. **Install Dependencies**
   ```bash
   # Open Package Manager Console in Visual Studio
   # Restore NuGet packages
   ```

2. **Setup Local Database**
   ```sql
   -- Run SQL scripts in Database/ folder
   -- Create local development database
   ```

3. **Configure Connection String**
   - Update `Web.config` with your local database connection

4. **Build Solution**
   - Open in Visual Studio
   - Press Ctrl + Shift + B to build

5. **Run Application**
   - Press F5 to start debugging
   - Application opens at http://localhost

---

## ✏️ Making Changes

### Code Style Guidelines

#### C# Conventions
```csharp
// ✅ DO - Use PascalCase for class and method names
public class StudentAttendanceManager
{
    public void MarkAttendance() { }
}

// ✅ DO - Use camelCase for local variables and parameters
public void ProcessAttendance(int studentId, string className)
{
    var attendanceDate = DateTime.Now;
}

// ✅ DO - Use meaningful names
public bool IsStudentPresent(int studentId, DateTime date) { }

// ❌ DON'T - Use abbreviations or single letters (except i, j in loops)
public bool IsStudentPrs(int sid, DateTime d) { }

// ✅ DO - Use proper indentation (4 spaces)
// ✅ DO - Add XML documentation for public methods
/// <summary>
/// Marks attendance for a student
/// </summary>
/// <param name="studentId">The student ID</param>
/// <param name="isPresent">Attendance status</param>
public void MarkAttendance(int studentId, bool isPresent)
{
    // Implementation
}
```

#### Comments & Documentation
```csharp
// ✅ DO - Write meaningful comments
// Check if attendance exceeds 75% threshold
if (attendancePercentage >= 75)

// ✅ DO - Add complexity explanation
// O(n) operation - iterates through all attendance records
foreach (var record in attendanceRecords)

// ❌ DON'T - State the obvious
// Increment i
i++;
```

#### File Organization
- One class per file
- File name matches class name
- Logical folder structure
- Namespace matches folder structure

---

## 📝 Commit Guidelines

### Commit Message Format

```
<type>(<scope>): <subject>

<body>

<footer>
```

### Type
- **feat**: New feature
- **fix**: Bug fix
- **docs**: Documentation change
- **style**: Code style change (formatting, etc)
- **refactor**: Code refactoring
- **perf**: Performance improvement
- **test**: Test addition or modification
- **chore**: Build, dependencies, tooling

### Scope
- `attendance` - Attendance module
- `student` - Student management
- `teacher` - Teacher management
- `admin` - Admin panel
- `report` - Reporting system
- `auth` - Authentication/Authorization
- `db` - Database schema

### Subject
- Use imperative mood ("add" not "added")
- Don't capitalize first letter
- No period at the end
- Limit to 50 characters

### Body
- Explain what and why, not how
- Wrap at 72 characters
- Separate from subject with blank line
- Use bullet points for multiple changes

### Footer
- Reference issues: `Fixes #123`
- Breaking changes: `BREAKING CHANGE: description`

### Examples

**Good Commit Messages:**
```
feat(attendance): add bulk attendance marking

Allow teachers to mark attendance for entire class at once.
Improves efficiency when marking large groups.

Fixes #42
```

```
fix(auth): resolve session timeout issue

Sessions now properly timeout after 30 minutes of inactivity.
Added session validation on each request.

Fixes #89
```

```
docs: update installation instructions for SQL Server setup
```

---

## 🔄 Submitting Pull Requests

### Before Submitting
1. **Update your branch**
   ```bash
   git fetch upstream
   git rebase upstream/main
   ```

2. **Run tests** (if applicable)
   - Ensure all tests pass

3. **Check for conflicts**
   - Resolve any merge conflicts

4. **Review your changes**
   - Use `git diff` to review changes

5. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

### Pull Request Template

```markdown
## Description
Brief description of changes

## Type of Change
- [ ] New feature
- [ ] Bug fix
- [ ] Breaking change
- [ ] Documentation update

## Related Issues
Fixes #(issue number)

## Testing
Describe testing performed

## Screenshots/Evidence
If applicable, add screenshots

## Checklist
- [ ] Code follows style guidelines
- [ ] Self-reviewed my own code
- [ ] Added comments for complex logic
- [ ] Updated documentation
- [ ] No new warnings generated
```

### PR Title Format
```
[FEATURE/FIX/DOCS] Brief description of change
```

**Examples:**
```
[FEATURE] Add bulk attendance marking capability
[FIX] Resolve session timeout issue
[DOCS] Update database setup instructions
```

---

## 🔍 Code Review Process

### What We Look For
- ✅ Code quality and style compliance
- ✅ Functionality works as intended
- ✅ No breaking changes without documentation
- ✅ Tests added/updated as needed
- ✅ Documentation updated
- ✅ Performance impact considered

### Review Timeline
- Initial review: 2-3 business days
- Changes requested: 1-2 business days for update
- Approval and merge: 1 business day

### Addressing Feedback
- Request clarification if needed
- Make requested changes
- Push updates to the same branch
- Comment when ready for re-review

---

## 🐛 Reporting Bugs

### Before Reporting
- Check existing issues (use search)
- Verify bug in latest version
- Gather system information

### Bug Report Template

```markdown
## Description
Clear description of the bug

## Steps to Reproduce
1. Login as [user type]
2. Navigate to [page]
3. Click [button]
4. Observe [unexpected behavior]

## Expected Behavior
What should happen

## Actual Behavior
What actually happens

## Screenshots
Attach relevant screenshots

## Environment
- OS: [Windows/Linux/Mac]
- Visual Studio Version: [version]
- .NET Framework: [version]
- SQL Server: [version]
- Browser: [if applicable]

## Additional Context
Any other relevant information
```

---

## 💡 Suggesting Enhancements

### Enhancement Request Template

```markdown
## Description
Clear description of the enhancement

## Motivation
Why is this enhancement needed?
What problem does it solve?

## Proposed Solution
How should this work?

## Alternatives Considered
Other approaches considered

## Additional Context
Screenshots, mockups, or examples
```

---

## 📚 Resources

- [C# Coding Guidelines](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [ASP.NET Best Practices](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/)
- [Git Workflow Guide](https://git-scm.com/book/en/v2)

---

## ❓ Questions?

- Check existing issues for answers
- Open a discussion if unclear
- Contact maintainers directly
- Review existing code for patterns

---

## 🎉 Thank You!

Your contributions help make this project better for everyone. We appreciate your time and effort!

**Happy coding!** 🚀
