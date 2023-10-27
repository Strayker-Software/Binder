## Binder - Business Requirements
__Template Version: 0.1.0__

### What is it?

Binder is a simple SaaS solution allowing you to create ToDo and custom lists of tasks in clean and readable way. You can create task from default pattern: name, description and completion indicator.

### What is it supposed to be used for?

- User login to tasks board,
- Add/edit/delete ToDo task,
- Add/edit/delete tables,
- Assign tasks to tables,
- Show/hide completed tasks in display,
- Show/hide selected columns,
- Reset view to default state,
- Show About App info,

### Main Functionalities:

- User Auth:
	- via GitHub SSO,
	- automatic, no login screen,

- ToDo Task Management:
	- Properties: Name, Description, Completed,
	- Add new task,
	- Edit existing task's values,
	- Delete task,
	- Assign to table,

- Tables Management:
	- One default table, unremovable, called: "ToDo List",
	- Add new table,
	- Edit table's name,
	- Delete table,

- Completed Tasks:
	- Button to show completed tasks,
	- Show uncompleted by default,
	- Adjust button's label respectively,

- Displayed Columns:
	- Modal to work on,
	- List of columns' names, with checked checkboxes,
	- Check - visible, uncheck - hidden,

- Reset View:
	- Restore columns visibility to default,
	- Restore task visibility to default,

- About App:
	- Popup,
	- Logo,
	- Name of app,
	- Version in "v(major).(minor).(Patch)" format,
	- Copyright notice,
	- License linking,
	- Link to project's GitHub,
