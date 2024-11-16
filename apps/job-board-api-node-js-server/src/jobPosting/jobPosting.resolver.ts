import * as graphql from "@nestjs/graphql";
import { JobPostingResolverBase } from "./base/jobPosting.resolver.base";
import { JobPosting } from "./base/JobPosting";
import { JobPostingService } from "./jobPosting.service";

@graphql.Resolver(() => JobPosting)
export class JobPostingResolver extends JobPostingResolverBase {
  constructor(protected readonly service: JobPostingService) {
    super(service);
  }
}
