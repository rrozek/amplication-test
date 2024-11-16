import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { ExtraSkillServiceBase } from "./base/extraSkill.service.base";

@Injectable()
export class ExtraSkillService extends ExtraSkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
