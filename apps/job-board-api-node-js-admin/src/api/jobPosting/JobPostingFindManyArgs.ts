import { JobPostingWhereInput } from "./JobPostingWhereInput";
import { JobPostingOrderByInput } from "./JobPostingOrderByInput";

export type JobPostingFindManyArgs = {
  where?: JobPostingWhereInput;
  orderBy?: Array<JobPostingOrderByInput>;
  skip?: number;
  take?: number;
};
