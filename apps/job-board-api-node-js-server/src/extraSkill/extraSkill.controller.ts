import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { ExtraSkillService } from "./extraSkill.service";
import { ExtraSkillControllerBase } from "./base/extraSkill.controller.base";

@swagger.ApiTags("extraSkills")
@common.Controller("extraSkills")
export class ExtraSkillController extends ExtraSkillControllerBase {
  constructor(protected readonly service: ExtraSkillService) {
    super(service);
  }
}
