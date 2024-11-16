/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";
import { Prisma, ExtraSkill as PrismaExtraSkill } from "@prisma/client";

export class ExtraSkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(
    args: Omit<Prisma.ExtraSkillCountArgs, "select">
  ): Promise<number> {
    return this.prisma.extraSkill.count(args);
  }

  async extraSkills(
    args: Prisma.ExtraSkillFindManyArgs
  ): Promise<PrismaExtraSkill[]> {
    return this.prisma.extraSkill.findMany(args);
  }
  async extraSkill(
    args: Prisma.ExtraSkillFindUniqueArgs
  ): Promise<PrismaExtraSkill | null> {
    return this.prisma.extraSkill.findUnique(args);
  }
  async createExtraSkill(
    args: Prisma.ExtraSkillCreateArgs
  ): Promise<PrismaExtraSkill> {
    return this.prisma.extraSkill.create(args);
  }
  async updateExtraSkill(
    args: Prisma.ExtraSkillUpdateArgs
  ): Promise<PrismaExtraSkill> {
    return this.prisma.extraSkill.update(args);
  }
  async deleteExtraSkill(
    args: Prisma.ExtraSkillDeleteArgs
  ): Promise<PrismaExtraSkill> {
    return this.prisma.extraSkill.delete(args);
  }
}
