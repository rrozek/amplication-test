import { Application as TApplication } from "../api/application/Application";

export const APPLICATION_TITLE_FIELD = "id";

export const ApplicationTitle = (record: TApplication): string => {
  return record.id?.toString() || String(record.id);
};
