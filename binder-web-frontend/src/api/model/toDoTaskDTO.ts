/**
 * Binder API
 * ASP.NET Core Web API backend app for Binder Solution
 *
 * The version of the OpenAPI document: v1
 *
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

export interface ToDoTaskDTO {
  readonly id?: number;
  name?: string | null;
  description?: string | null;
  isCompleted?: boolean;
  tableId?: number;
}
