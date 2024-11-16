import { JobPostingSkill as TJobPostingSkill } from "../api/jobPostingSkill/JobPostingSkill";

export const JOBPOSTINGSKILL_TITLE_FIELD = "id";

export const JobPostingSkillTitle = (record: TJobPostingSkill): string => {
  return record.id?.toString() || String(record.id);
};
