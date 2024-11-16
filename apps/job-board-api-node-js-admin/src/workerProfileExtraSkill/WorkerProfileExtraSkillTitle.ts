import { WorkerProfileExtraSkill as TWorkerProfileExtraSkill } from "../api/workerProfileExtraSkill/WorkerProfileExtraSkill";

export const WORKERPROFILEEXTRASKILL_TITLE_FIELD = "id";

export const WorkerProfileExtraSkillTitle = (
  record: TWorkerProfileExtraSkill
): string => {
  return record.id?.toString() || String(record.id);
};
