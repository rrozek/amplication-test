import { Module } from "@nestjs/common";
import { WorkerProfileSkillModuleBase } from "./base/workerProfileSkill.module.base";
import { WorkerProfileSkillService } from "./workerProfileSkill.service";
import { WorkerProfileSkillController } from "./workerProfileSkill.controller";
import { WorkerProfileSkillResolver } from "./workerProfileSkill.resolver";

@Module({
  imports: [WorkerProfileSkillModuleBase],
  controllers: [WorkerProfileSkillController],
  providers: [WorkerProfileSkillService, WorkerProfileSkillResolver],
  exports: [WorkerProfileSkillService],
})
export class WorkerProfileSkillModule {}
