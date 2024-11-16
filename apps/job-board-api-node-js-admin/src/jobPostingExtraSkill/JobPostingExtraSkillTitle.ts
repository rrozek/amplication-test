import { JobPostingExtraSkill as TJobPostingExtraSkill } from "../api/jobPostingExtraSkill/JobPostingExtraSkill";

export const JOBPOSTINGEXTRASKILL_TITLE_FIELD = "id";

export const JobPostingExtraSkillTitle = (
  record: TJobPostingExtraSkill
): string => {
  return record.id?.toString() || String(record.id);
};
