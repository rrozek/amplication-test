import * as graphql from "@nestjs/graphql";
import { WorkerProfileSkillResolverBase } from "./base/workerProfileSkill.resolver.base";
import { WorkerProfileSkill } from "./base/WorkerProfileSkill";
import { WorkerProfileSkillService } from "./workerProfileSkill.service";

@graphql.Resolver(() => WorkerProfileSkill)
export class WorkerProfileSkillResolver extends WorkerProfileSkillResolverBase {
  constructor(protected readonly service: WorkerProfileSkillService) {
    super(service);
  }
}
