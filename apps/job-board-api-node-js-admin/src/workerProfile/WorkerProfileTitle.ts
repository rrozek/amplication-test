import { WorkerProfile as TWorkerProfile } from "../api/workerProfile/WorkerProfile";

export const WORKERPROFILE_TITLE_FIELD = "id";

export const WorkerProfileTitle = (record: TWorkerProfile): string => {
  return record.id?.toString() || String(record.id);
};
