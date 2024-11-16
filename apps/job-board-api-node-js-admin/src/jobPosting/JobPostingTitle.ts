import { JobPosting as TJobPosting } from "../api/jobPosting/JobPosting";

export const JOBPOSTING_TITLE_FIELD = "id";

export const JobPostingTitle = (record: TJobPosting): string => {
  return record.id?.toString() || String(record.id);
};
