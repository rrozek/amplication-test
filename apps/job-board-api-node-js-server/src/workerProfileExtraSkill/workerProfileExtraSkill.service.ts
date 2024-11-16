import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { WorkerProfileExtraSkillServiceBase } from "./base/workerProfileExtraSkill.service.base";

@Injectable()
export class WorkerProfileExtraSkillService extends WorkerProfileExtraSkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
