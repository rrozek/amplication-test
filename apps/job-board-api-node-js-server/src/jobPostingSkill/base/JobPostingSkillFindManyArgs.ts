/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { JobPostingSkillWhereInput } from "./JobPostingSkillWhereInput";
import { IsOptional, ValidateNested, IsInt } from "class-validator";
import { Type } from "class-transformer";
import { JobPostingSkillOrderByInput } from "./JobPostingSkillOrderByInput";

@ArgsType()
class JobPostingSkillFindManyArgs {
  @ApiProperty({
    required: false,
    type: () => JobPostingSkillWhereInput,
  })
  @IsOptional()
  @ValidateNested()
  @Field(() => JobPostingSkillWhereInput, { nullable: true })
  @Type(() => JobPostingSkillWhereInput)
  where?: JobPostingSkillWhereInput;

  @ApiProperty({
    required: false,
    type: [JobPostingSkillOrderByInput],
  })
  @IsOptional()
  @ValidateNested({ each: true })
  @Field(() => [JobPostingSkillOrderByInput], { nullable: true })
  @Type(() => JobPostingSkillOrderByInput)
  orderBy?: Array<JobPostingSkillOrderByInput>;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  skip?: number;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  take?: number;
}

export { JobPostingSkillFindManyArgs as JobPostingSkillFindManyArgs };
