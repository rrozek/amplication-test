import * as graphql from "@nestjs/graphql";
import { JobPostingSkillResolverBase } from "./base/jobPostingSkill.resolver.base";
import { JobPostingSkill } from "./base/JobPostingSkill";
import { JobPostingSkillService } from "./jobPostingSkill.service";

@graphql.Resolver(() => JobPostingSkill)
export class JobPostingSkillResolver extends JobPostingSkillResolverBase {
  constructor(protected readonly service: JobPostingSkillService) {
    super(service);
  }
}
