import { WorkerProfileSkill as TWorkerProfileSkill } from "../api/workerProfileSkill/WorkerProfileSkill";

export const WORKERPROFILESKILL_TITLE_FIELD = "id";

export const WorkerProfileSkillTitle = (
  record: TWorkerProfileSkill
): string => {
  return record.id?.toString() || String(record.id);
};
