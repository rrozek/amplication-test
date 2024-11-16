import { JobPostingSkillWhereInput } from "./JobPostingSkillWhereInput";
import { JobPostingSkillOrderByInput } from "./JobPostingSkillOrderByInput";

export type JobPostingSkillFindManyArgs = {
  where?: JobPostingSkillWhereInput;
  orderBy?: Array<JobPostingSkillOrderByInput>;
  skip?: number;
  take?: number;
};
