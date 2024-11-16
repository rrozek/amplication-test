import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { WorkerProfileSkillService } from "./workerProfileSkill.service";
import { WorkerProfileSkillControllerBase } from "./base/workerProfileSkill.controller.base";

@swagger.ApiTags("workerProfileSkills")
@common.Controller("workerProfileSkills")
export class WorkerProfileSkillController extends WorkerProfileSkillControllerBase {
  constructor(protected readonly service: WorkerProfileSkillService) {
    super(service);
  }
}
