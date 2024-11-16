import { Module } from "@nestjs/common";
import { WorkerProfileExtraSkillModuleBase } from "./base/workerProfileExtraSkill.module.base";
import { WorkerProfileExtraSkillService } from "./workerProfileExtraSkill.service";
import { WorkerProfileExtraSkillController } from "./workerProfileExtraSkill.controller";
import { WorkerProfileExtraSkillResolver } from "./workerProfileExtraSkill.resolver";

@Module({
  imports: [WorkerProfileExtraSkillModuleBase],
  controllers: [WorkerProfileExtraSkillController],
  providers: [WorkerProfileExtraSkillService, WorkerProfileExtraSkillResolver],
  exports: [WorkerProfileExtraSkillService],
})
export class WorkerProfileExtraSkillModule {}
