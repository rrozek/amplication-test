import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { SkillList } from "./skill/SkillList";
import { SkillCreate } from "./skill/SkillCreate";
import { SkillEdit } from "./skill/SkillEdit";
import { SkillShow } from "./skill/SkillShow";
import { WorkerProfileList } from "./workerProfile/WorkerProfileList";
import { WorkerProfileCreate } from "./workerProfile/WorkerProfileCreate";
import { WorkerProfileEdit } from "./workerProfile/WorkerProfileEdit";
import { WorkerProfileShow } from "./workerProfile/WorkerProfileShow";
import { ApplicationList } from "./application/ApplicationList";
import { ApplicationCreate } from "./application/ApplicationCreate";
import { ApplicationEdit } from "./application/ApplicationEdit";
import { ApplicationShow } from "./application/ApplicationShow";
import { WorkerProfileExtraSkillList } from "./workerProfileExtraSkill/WorkerProfileExtraSkillList";
import { WorkerProfileExtraSkillCreate } from "./workerProfileExtraSkill/WorkerProfileExtraSkillCreate";
import { WorkerProfileExtraSkillEdit } from "./workerProfileExtraSkill/WorkerProfileExtraSkillEdit";
import { WorkerProfileExtraSkillShow } from "./workerProfileExtraSkill/WorkerProfileExtraSkillShow";
import { JobPostingSkillList } from "./jobPostingSkill/JobPostingSkillList";
import { JobPostingSkillCreate } from "./jobPostingSkill/JobPostingSkillCreate";
import { JobPostingSkillEdit } from "./jobPostingSkill/JobPostingSkillEdit";
import { JobPostingSkillShow } from "./jobPostingSkill/JobPostingSkillShow";
import { JobPostingList } from "./jobPosting/JobPostingList";
import { JobPostingCreate } from "./jobPosting/JobPostingCreate";
import { JobPostingEdit } from "./jobPosting/JobPostingEdit";
import { JobPostingShow } from "./jobPosting/JobPostingShow";
import { ExtraSkillList } from "./extraSkill/ExtraSkillList";
import { ExtraSkillCreate } from "./extraSkill/ExtraSkillCreate";
import { ExtraSkillEdit } from "./extraSkill/ExtraSkillEdit";
import { ExtraSkillShow } from "./extraSkill/ExtraSkillShow";
import { JobPostingExtraSkillList } from "./jobPostingExtraSkill/JobPostingExtraSkillList";
import { JobPostingExtraSkillCreate } from "./jobPostingExtraSkill/JobPostingExtraSkillCreate";
import { JobPostingExtraSkillEdit } from "./jobPostingExtraSkill/JobPostingExtraSkillEdit";
import { JobPostingExtraSkillShow } from "./jobPostingExtraSkill/JobPostingExtraSkillShow";
import { WorkerProfileSkillList } from "./workerProfileSkill/WorkerProfileSkillList";
import { WorkerProfileSkillCreate } from "./workerProfileSkill/WorkerProfileSkillCreate";
import { WorkerProfileSkillEdit } from "./workerProfileSkill/WorkerProfileSkillEdit";
import { WorkerProfileSkillShow } from "./workerProfileSkill/WorkerProfileSkillShow";
import { UserList } from "./user/UserList";
import { UserCreate } from "./user/UserCreate";
import { UserEdit } from "./user/UserEdit";
import { UserShow } from "./user/UserShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"JobBoardAPI-NodeJs"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="Skill"
          list={SkillList}
          edit={SkillEdit}
          create={SkillCreate}
          show={SkillShow}
        />
        <Resource
          name="WorkerProfile"
          list={WorkerProfileList}
          edit={WorkerProfileEdit}
          create={WorkerProfileCreate}
          show={WorkerProfileShow}
        />
        <Resource
          name="Application"
          list={ApplicationList}
          edit={ApplicationEdit}
          create={ApplicationCreate}
          show={ApplicationShow}
        />
        <Resource
          name="WorkerProfileExtraSkill"
          list={WorkerProfileExtraSkillList}
          edit={WorkerProfileExtraSkillEdit}
          create={WorkerProfileExtraSkillCreate}
          show={WorkerProfileExtraSkillShow}
        />
        <Resource
          name="JobPostingSkill"
          list={JobPostingSkillList}
          edit={JobPostingSkillEdit}
          create={JobPostingSkillCreate}
          show={JobPostingSkillShow}
        />
        <Resource
          name="JobPosting"
          list={JobPostingList}
          edit={JobPostingEdit}
          create={JobPostingCreate}
          show={JobPostingShow}
        />
        <Resource
          name="ExtraSkill"
          list={ExtraSkillList}
          edit={ExtraSkillEdit}
          create={ExtraSkillCreate}
          show={ExtraSkillShow}
        />
        <Resource
          name="JobPostingExtraSkill"
          list={JobPostingExtraSkillList}
          edit={JobPostingExtraSkillEdit}
          create={JobPostingExtraSkillCreate}
          show={JobPostingExtraSkillShow}
        />
        <Resource
          name="WorkerProfileSkill"
          list={WorkerProfileSkillList}
          edit={WorkerProfileSkillEdit}
          create={WorkerProfileSkillCreate}
          show={WorkerProfileSkillShow}
        />
        <Resource
          name="User"
          list={UserList}
          edit={UserEdit}
          create={UserCreate}
          show={UserShow}
        />
      </Admin>
    </div>
  );
};

export default App;
