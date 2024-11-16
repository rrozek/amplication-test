import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { WorkerProfileSkillServiceBase } from "./base/workerProfileSkill.service.base";

@Injectable()
export class WorkerProfileSkillService extends WorkerProfileSkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
