import * as graphql from "@nestjs/graphql";
import { WorkerProfileExtraSkillResolverBase } from "./base/workerProfileExtraSkill.resolver.base";
import { WorkerProfileExtraSkill } from "./base/WorkerProfileExtraSkill";
import { WorkerProfileExtraSkillService } from "./workerProfileExtraSkill.service";

@graphql.Resolver(() => WorkerProfileExtraSkill)
export class WorkerProfileExtraSkillResolver extends WorkerProfileExtraSkillResolverBase {
  constructor(protected readonly service: WorkerProfileExtraSkillService) {
    super(service);
  }
}
