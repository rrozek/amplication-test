import * as graphql from "@nestjs/graphql";
import { JobPostingExtraSkillResolverBase } from "./base/jobPostingExtraSkill.resolver.base";
import { JobPostingExtraSkill } from "./base/JobPostingExtraSkill";
import { JobPostingExtraSkillService } from "./jobPostingExtraSkill.service";

@graphql.Resolver(() => JobPostingExtraSkill)
export class JobPostingExtraSkillResolver extends JobPostingExtraSkillResolverBase {
  constructor(protected readonly service: JobPostingExtraSkillService) {
    super(service);
  }
}
