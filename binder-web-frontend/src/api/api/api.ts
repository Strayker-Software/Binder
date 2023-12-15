export * from './appVersions.service';
import { AppVersionsService } from './appVersions.service';
export * from './auth.service';
import { AuthService } from './auth.service';
export * from './tables.service';
import { TablesService } from './tables.service';
export * from './toDoTasks.service';
import { ToDoTasksService } from './toDoTasks.service';
export const APIS = [AppVersionsService, AuthService, TablesService, ToDoTasksService];
