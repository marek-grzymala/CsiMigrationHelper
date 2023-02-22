using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class TrackingTblHndlr
    {
        private ComboBoxExtTrackTbl ProjectsTable;
        private ComboBoxExtTrackTbl ProjectName;
        TextBox TbxSrc;
        TextBox TbxTgt;
        private DataGridView  GridTrackingTable;
        private EventArgsProjectFields pf;
        private ProjectFields pf_new;
        private ImageList ImageList1;
        private Button BtnTrackingLoadSrcCount;
        private Button BtnTrackingRunImport;
        private string UspNamePreloadMigrationTrackingTbl;


        public TrackingTblHndlr(  ComboBoxExtTrackTbl projectsTable
                                , ComboBoxExtTrackTbl projectName
                                , TextBox tbxSrc
                                , TextBox tbxTgt
                                , DataGridView gridTrackingTable
                                , EventArgsProjectFields projectFields
                                , ImageList imageList1
                                , Button btnTrackingLoadSrcCount
                                , Button btnTrackingRunImport
                                )
        {
            ProjectsTable = projectsTable;
            ProjectName   = projectName;
            TbxSrc = tbxSrc;
            TbxTgt = tbxTgt;
            GridTrackingTable = gridTrackingTable;
            pf = projectFields;

            ProjectsTable.RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonProjectsTableCheckedChanged);
            ProjectsTable.eventCmbxTrackTblSelectedIndexChanged += new HandlerCmbxProjectTblSelectedIndexChanged(OnCmbxProjectsTableSelectedIndexChange);
            ProjectName.eventCmbxProjectNameSelectedIndexChanged += new HandlerCmbxProjectSelectedIndexChanged(OnCmbxProjectNameSelectedIndexChange);
            ProjectName.eventCmbxProjectSelectionEmpty += new HandlerCmbxProjectSelectionEmpty(OnCmbxProjectSelectionEmpty);



            ProjectsTable.SaveButton.Click += new EventHandler(OnProjectsTableSaveButtonClick);
            ProjectName.SaveButton.Click += new EventHandler(OnProjectNameSaveButtonClick);
            ImageList1 = imageList1;

            BtnTrackingLoadSrcCount = btnTrackingLoadSrcCount;
            BtnTrackingLoadSrcCount.Click += new EventHandler(OnBtnTrackingLoadSrcCountClick);
            BtnTrackingRunImport = btnTrackingRunImport;
            //BtnTrackingLoadSrcCount.Click += new EventHandler(OnBtnTrackingRunImportClick);
            pf_new = new ProjectFields();
        }


        protected virtual void OnProjectsTableSaveButtonClick(object sender, EventArgs ea)
        {
            if (pf.SrcIndex.IsBranchTextSet(pf.SrcIndex, (int)DbObjectLevel.Instance) &&
                pf.TgtIndex.IsBranchTextSet(pf.TgtIndex, (int)DbObjectLevel.Instance))
            {
                if (ProjectsTable.RdButtonCreateNew.Checked && ProjectsTable.Text.Length > 0)
                {
                    EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                                              ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                            , ProjectsTable.TreeNodeOwner
                                            , ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Database).ToString()
                                            , ProjectsTable.TreeNodeOwner.Parent.ToString()
                                            , ProjectsTable.TreeNodeOwner.ToString());

                    if (CreateProjectsTableAndUspGetProjectSettings(e))
                    {
                        pf.TrackSynonymProjects = string.Concat("Track_", e.InstanceNode.ToString(), "_", e.SchemaName.ToString(), "_", e.TableName.ToString());
                        pf.TrackSynonymMigrationTrck = string.Concat("Track_", e.InstanceNode.ToString(), "_", e.SchemaName.ToString(), "_", e.TableName.ToString(), Options.migrationTrackingTblSuffix);

                        ProjectsTable.LockGuiControls();
                        ProjectsTable.SaveButton.Image = ImageList1.Images[0];
                    }
                    else
                    {
                        ProjectsTable.SaveButton.Image = ImageList1.Images[1];
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Concat("Missing Source/Target Config"), "Missing Source/Target Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnProjectNameSaveButtonClick(object sender, EventArgs ea)
        {
            if (pf.SrcIndex.IsBranchTextSet(pf.SrcIndex, (int)DbObjectLevel.Instance) &&
                pf.TgtIndex.IsBranchTextSet(pf.TgtIndex, (int)DbObjectLevel.Instance))
            {
                if (ProjectName.RdButtonCreateNew.Checked && ProjectName.Text.Length > 0)
                {
                    EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                                          ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                        , ProjectsTable.TreeNodeOwner
                                        , ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Database).ToString()
                                        , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                                        , ProjectsTable.TreeNodeOwner.Data.ObjectText);

                    pf.SrcSynonym = string.Concat("Src_", pf.SrcInstance, "_", pf.SrcSchema, "_", pf.SrcTable);
                    pf.TgtSynonym = string.Concat("Tgt_", pf.TgtInstance, "_", pf.TgtArchiveSchema, "_", pf.TgtArchiveTable);
                    pf_new.SrcSynonym = pf.SrcSynonym; //string.Concat("Src_", pf.SrcInstance, "_", pf.SrcSchema, "_", pf.SrcTable);
                    pf_new.TgtSynonym = pf.TgtSynonym; // string.Concat("Tgt_", pf.TgtInstance, "_", pf.TgtArchiveSchema, "_", pf.TgtArchiveTable);

                    if (CreateProject(e, ProjectName.TreeNodeOwner.ToString(), ProjectName.ProjectDescription.Text))
                    {                        
                        ProjectName.LockGuiControls();
                        ProjectName.SaveButton.Image = ImageList1.Images[0];
                        //Create Tgt Linked Server:
                        if (CreateLinkedServers(e, pf.TgtInstance.Data.Dbu))
                        {
                            CreateSynonyms(e);
                            e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                            , SqlText.GetSqlUspUpdateMigrationTrackingSrcCountPerProjectName(
                                                                  e.SchemaName
                                                                , e.TableName
                                                                , ProjectName.TreeNodeOwner.ToString()
                                                                , pf_new.SrcSynonym
                                                                , null
                                                                , pf_new.SrcDatabase
                                                                , pf_new.SrcSchema
                                                                , pf_new.SrcTable
                                                                , pf_new.SrcColumn
                                )
                            , string.Concat("Error Creating usp: [", e.SchemaName, "].[usp_Update_", e.SchemaName, e.TableName, Options.migrationTrackingTblSuffix, "_SrcCountPer_", ProjectName.TreeNodeOwner.ToString(), "]")); ;

                            //Create Usp Preloading the migration tracking table:
                            if (CreateUspPreloadMigrationTrackingTbl(e, pf_new))
                            {
                                string projectTableSchema = ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText;
                                string projectTableName = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                                Console.WriteLine(string.Concat("Successfully Created usp: [", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "_", ProjectName.TreeNodeOwner.ToString(), "]"));
                                UspNamePreloadMigrationTrackingTbl = string.Concat("[", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "_", ProjectName.TreeNodeOwner.ToString(), "]");

                                int r = RunUspPreloadMigrationTrackingTbl(e, pf_new);
                                if (r > 0)
                                {
                                    Console.WriteLine(string.Concat("Procedure: ", UspNamePreloadMigrationTrackingTbl, " returned :", r, " records"));

                                    // update Project entry with Synonym for Migration Tracking Table:
                                    UpdateProjectTblSetTrackTblSynonyms(e, pf.TrackSynonymProjects, pf.TrackSynonymMigrationTrck);                                    



                                    if (LoadGrid(e))
                                    {
                                        TbxSrc.Text = string.Concat("[",        pf_new.SrcInstance
                                                                       , "].[", pf_new.SrcDatabase
                                                                       , "].[", pf_new.SrcSchema
                                                                       , "].[", pf_new.SrcTable, "]"
                                                                       );
                                        TbxTgt.Text = string.Concat("[",        pf_new.TgtInstance
                                                                       , "].[", pf_new.TgtDatabase
                                                                       , "].[", pf_new.TgtArchiveSchema
                                                                       , "].[", pf_new.TgtArchiveTable, "]"
                                                                       );                                                                                
                                    }
                                }
                                //else
                                //{
                                //    MessageBox.Show(string.Concat("Procedure: ", UspNamePreloadMigrationTrackingTbl
                                //        , " did not insert any records; ", Environment.NewLine, "Removing Project: [", ProjectName.TreeNodeOwner.ToString(), "]")
                                //        , "No Entries Inserted into Migration Tracking Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    RemoveProject(e, ProjectName.TreeNodeOwner.ToString());
                                //    OnCmbxProjectSelectionEmpty(this, e);
                                //}
                                // drop the usp (it contains a hard-coded linked server definition which may not be valid for new projects after this one)
                                //DropUspPreloadMigrationTrackingTbl(e, UspNamePreloadMigrationTrackingTbl);
                            }
                            else
                            {
                                RemoveProject(e, ProjectName.TreeNodeOwner.ToString());
                                OnCmbxProjectSelectionEmpty(this, e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to create Linked Servers!");
                            RemoveProject(e, ProjectName.TreeNodeOwner.ToString());
                            OnCmbxProjectSelectionEmpty(this, e);
                        }
                    }
                    else
                    {
                        ProjectName.SaveButton.Image = ImageList1.Images[1];
                    }
                }
                else
                {
                    MessageBox.Show(string.Concat("Missing Source/Target Config"), "Missing Source/Target Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // if Create New ProjectTable option chosen allow only creating new Projects in it (there is no existing Projects in a New ProjectTable):
        protected virtual void OnRdButtonProjectsTableCheckedChanged(object sender, EventArgs e)
        {            
            if (ProjectsTable.RdButtonCreateNew.Checked)
            {
                ProjectName.UnLockGuiControls(this, EventArgs.Empty);
                ProjectName.RdButtonUseExisting.Enabled = false;
                ProjectName.RdButtonCreateNew.Checked = true;
                ProjectName.RunOnRdButtonCheckedChanged(sender, EventArgs.Empty);
            }
            else
            {
                ProjectName.RdButtonUseExisting.Enabled = true;
            }
        }

        protected virtual void OnCmbxProjectsTableSelectedIndexChange(object sender, EventArgsMigrationTracking e)
        {            
            if (ProjectsTable.SelectedIndex > 0 && VerifyTableName(e))
            {
                ProjectsTable.ProjectTableNameValid = true;
                ProjectName.UnLockGuiControls(this, EventArgs.Empty);                
            }
            else
            {
                ProjectsTable.ProjectTableNameValid = false;
                ProjectName.LockGuiControls();
                MessageBox.Show(string.Concat("Table: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText
                    , " is an invalid Project Table"), "Invalid Project Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected virtual void OnCmbxProjectNameSelectedIndexChange(object sender, EventArgsMigrationTracking e)
        {
            if (ProjectName.SelectedIndex > 0 && VerifyProjectNameEntriesPresentInMgrTrckgTbl(e))
            {
                // fill out Src and Tgt Textboxes:
                string newCbxSelection = ProjectName.TreeNodeOwner.Data.Gui.GetCbxSelectionChangeCommited(
                    ParamSelector.GetParamMetaByObjectLvl(ProjectName.TreeNodeOwner.Data.ObjectLevel
                                                        , ProjectName.TreeNodeOwner.Data.ObjectBranch).DisplayMember);
                RunUspGetProjectSettingsByProjectName(newCbxSelection, e);

                ProjectName.ProjectNameValid = true;
                GridTrackingTable.DataSource = null;
                if (LoadGrid(e))
                {                    
                    BtnTrackingLoadSrcCount.Enabled = true;
                    BtnTrackingLoadSrcCount.Image = null;
                }
                else
                {
                    BtnTrackingLoadSrcCount.Enabled = false;
                    BtnTrackingLoadSrcCount.Image = null;
                }
            }
            else
            {
                ProjectName.ProjectNameValid = false;
                TbxSrc.Text = null;
                TbxTgt.Text = null;
                GridTrackingTable.DataSource = null;

                MessageBox.Show(string.Concat("Project: [", ProjectName.TreeNodeOwner,ToString()
                                          , "] listed in Table: [", e.SchemaName, "].[", ProjectsTable.TreeNodeOwner.ToString()
                                          , "] on Instance: [", e.InstanceNode.ToString()
                                          , "] does not have any entries in table: [", ProjectsTable.TreeNodeOwner, Options.migrationTrackingTblSuffix
                                          , "]"), "No Entries in Migration Tracking Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnCmbxProjectSelectionEmpty(object sender, EventArgsMigrationTracking e)
        {
            if (!string.IsNullOrEmpty(TbxSrc.Text))
            {
                TbxSrc.Text = null;
            }
            if (!string.IsNullOrEmpty(TbxTgt.Text))
            {
                TbxTgt.Text = null;
            }
            if (GridTrackingTable.DataSource != null)
            {
                GridTrackingTable.DataSource = null;
                BtnTrackingLoadSrcCount.Image = null;
                BtnTrackingLoadSrcCount.Enabled = false;
            }
        }

        private bool VerifyTableName(EventArgsMigrationTracking e)
        {
            bool result = false;               
            if (e.InstanceNode.Data.Dbu.ParseSql(e.InstanceNode, SqlText.GetSqlTableVerificationProjectsTable(e.SchemaName, e.TableName)))
            {                    
                result = e.InstanceNode.Data.Dbu.ExecuteSqlScalar(e.InstanceNode
                    , SqlText.GetSqlTableVerificationProjectsTable(e.SchemaName, e.TableName)
                    , null ) == 28 ? true : false;
            }
            return result;
        }

        private bool VerifyProjectNameEntriesPresentInMgrTrckgTbl(EventArgsMigrationTracking e)
        {
            bool result = false;
            if (e.InstanceNode.Data.Dbu.ParseSql(e.InstanceNode, SqlText.GetSqlVerifyMigrationTrackingEntryCountPerProjectName(e.TreeNodeOwner)))
            {
                result = e.InstanceNode.Data.Dbu.ExecuteSqlScalar(e.InstanceNode
                    , SqlText.GetSqlVerifyMigrationTrackingEntryCountPerProjectName(e.TreeNodeOwner)
                    , null) > 0 ? true : false;
            }
            return result;
        }

        private bool CreateProjectsTableAndUspGetProjectSettings(EventArgsMigrationTracking e)
        {

            bool result = false;
            try
            {
                result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                    , SqlText.GetSqlTableDefinitionProjectTable(e.SchemaName, e.TableName)
                    , "Error creating Project Table: [" + e.SchemaName +"].["+ e.TableName +"]");

                if (!result)
                {
                    return false;
                }
                result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlProjectSettingsByProjectName(e.SchemaName, e.TableName)
                       , string.Concat("Error Creating usp: [", e.SchemaName, "].[usp_GetProjectSettingsFrom_", e.SchemaName, "_", e.TableName, "]"));
                if (!result)
                {
                    return false;
                }
                return result;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateProject(EventArgsMigrationTracking e, string projectName, string projectDescription)
        {
            try
            {
                bool result = false;
                result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlProjectInsert(e.SchemaName, e.TableName, projectName, projectDescription, pf)
                       , "Error creating Project: ["+ projectName + "]");

                if (!result)
                {
                    MessageBox.Show(string.Concat("Failed to create Project: ", projectName), "Empty fileds for synonym?"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    pf_new.RunUspGetProjectSettingsByProjectName(projectName, e);
                }
                
                return result;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }

        }

        private bool RemoveProject(EventArgsMigrationTracking e, string projectName)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlProjectRemove(e.SchemaName, e.TableName, projectName)
                       , "Error removing Project: [" + projectName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateLinkedServers(EventArgsMigrationTracking e, DbUtil dbu)
        {
            bool result = false;
            try
            {
                result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlAddLinkedServer(pf.SrcInstance.ToString(), dbu)
                       , "Error creating LinkedServer: [" + pf.SrcInstance.ToString() + "]");
                
                if (!result)
                {
                    return false;
                }
                
                result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlAddLinkedServer(pf_new.TgtInstance.ToString(), dbu)
                       , "Error creating LinkedServer: [" + pf_new.TgtInstance.ToString() + "]");
                
                if (!result)
                {
                    return false;
                }

                return result;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return result;
            }
        }

        private bool CreateSynonyms(EventArgsMigrationTracking e)
        {
            bool result = false;
            try
            {

                result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlAddSynonym(pf_new.SrcSynonym
                                                , pf_new.SrcInstance.ToString()
                                                , pf_new.SrcDatabase.ToString()
                                                , pf_new.SrcSchema.ToString()
                                                , pf_new.SrcTable.ToString()
                                                )
                       , "Error creating a Synonym: [" + pf_new.SrcInstance.ToString() + "]");
                if (!result)
                {
                    return false;
                }


                //result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                //       , SqlText.GetSqlAddSynonym(pf_new.TgtSynonym
                //                                , pf_new.TgtInstance.ToString()
                //                                , pf_new.TgtDatabase.ToString()
                //                                , pf_new.TgtArchiveSchema.ToString()
                //                                , pf_new.TgtArchiveTable.ToString()
                //                                )
                //       , "Error creating Synonym: [" + pf_new.SrcInstance.ToString() + "]");

                //if (!result)
                //{
                //    return false;
                //}

                //result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                //       , SqlText.GetSqlAddSynonym(pf_new.TrackSynonymProjects
                //                                , e.InstanceNode.ToString()
                //                                , e.DatabaseName
                //                                , e.SchemaName
                //                                , e.TableName
                //                                )
                //       , "Error creating Synonym: [" + pf.SrcInstance.ToString() + "]");

                //if (!result)
                //{
                //    return false;
                //}

                //result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                //       , SqlText.GetSqlAddSynonym(pf_new.TrackSynonymMigrationTrck
                //                                , e.InstanceNode.ToString()
                //                                , e.DatabaseName
                //                                , e.SchemaName
                //                                , string.Concat(e.TableName, Options.migrationTrackingTblSuffix)
                //                                )
                //       , "Error creating Synonym: [" + pf_new.SrcInstance.ToString() + "]");

                //result = e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                //       , SqlText.GetSqlAddSynonym(pf_new.TrackSynonymMigrationTrck
                //                                , e.InstanceNode.ToString()
                //                                , e.DatabaseName
                //                                , e.SchemaName
                //                                , string.Concat(e.TableName, Options.migrationTrackingTblSuffix)
                //                                )
                //       , "Error creating Synonym: [" + pf_new.SrcInstance.ToString() + "]");
                //return result;

                return result;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return result;
            }
        }

        private bool UpdateProjectTblSetTrackTblSynonyms(EventArgsMigrationTracking e
                                                       , string synonymMigrationProjectsTable
                                                       , string synonymMigrationTrackingTbl)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                       , SqlText.GetSqlUpdateProjectTblSetTrackTblSynonyms(e.SchemaName, e.TableName, ProjectName.TreeNodeOwner.ToString(), synonymMigrationProjectsTable, synonymMigrationTrackingTbl)
                       , "Error updating [" + e.SchemaName + "].[" + e.TableName + "] when Setting Synonyms: [" + synonymMigrationProjectsTable + "] and [" + synonymMigrationTrackingTbl + "] for Project" + ProjectName.TreeNodeOwner.ToString());
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateUspPreloadMigrationTrackingTbl(EventArgsMigrationTracking eMtr, ProjectFields eProjFields)
        {
            try
            {                
                string projectTableSchema = ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText;
                string projectTableName = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                string projectName = ProjectName.TreeNodeOwner.Data.ObjectText;
                //Console.WriteLine(SqlText.GetSqlCreateUspPreloadMigrationTracking(projectTableSchema, projectTableName, eProjFields));
                
                return eMtr.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(eMtr.InstanceNode
                       , SqlText.GetSqlCreateUspPreloadMigrationTracking(projectTableSchema, projectTableName, eProjFields, ProjectName.TreeNodeOwner.ToString())
                       , string.Concat("Error Creating usp: [", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "]"));
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool DropUspPreloadMigrationTrackingTbl(EventArgsMigrationTracking eMtr, string uspName)
        {
            try
            {
                return eMtr.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(eMtr.InstanceNode
                       , string.Concat("DROP PROCEDURE IF EXISTS ", uspName)
                       , string.Concat("Error Dropping usp: [", uspName, "]"));
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private int RunUspPreloadMigrationTrackingTbl(EventArgsMigrationTracking eMtr, ProjectFields eProjFields)
        {
            try
            {
                string projectName = ProjectName.TreeNodeOwner.Data.ObjectText;
                string projectTableSchema = ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText;
                string projectTableName = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                //Console.WriteLine(SqlText.GetSqlCreateUspPreloadMigrationTracking(projectTableSchema, projectTableName, eProjFields));

                if (eProjFields.TgtArchiveSchema.ToString().Length < 1)
                {
                    MessageBox.Show(string.Concat("eProjFields.TgtArchiveSchema.ToString().Length <1"), "Empty fileds for synonym?"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (eProjFields.TgtArchiveTable.ToString().Length < 1)
                {
                    MessageBox.Show(string.Concat("eProjFields.TgtArchiveTable.ToString().Length <1"), "Empty fileds for synonym?"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (eProjFields.TgtIndex.ToString().Length < 1)
                {
                    MessageBox.Show(string.Concat("eProjFields.TgtIndex.ToString()"), "Empty fileds for synonym?"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                

                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                SqlParameter p_ProjectName = new SqlParameter()
                {
                    ParameterName = "@ProjectName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = projectName
                };
                sqlParamList.Add(p_ProjectName);

                
                SqlParameter p_TgtSchema = new SqlParameter()
                {
                    ParameterName = "@TgtSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = eProjFields.TgtArchiveSchema.ToString()
                };
                sqlParamList.Add(p_TgtSchema);

                SqlParameter p_TgtTable = new SqlParameter()
                {
                    ParameterName = "@TgtTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = eProjFields.TgtArchiveTable.ToString()
                };
                sqlParamList.Add(p_TgtTable);

                SqlParameter p_TgtIndex = new SqlParameter()
                {
                    ParameterName = "@TgtIndex",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = eProjFields.TgtIndex.ToString()
                };
                sqlParamList.Add(p_TgtIndex);
                return eMtr.InstanceNode.Data.Dbu.ExecuteSqlUsp(eMtr.InstanceNode, UspNamePreloadMigrationTrackingTbl, sqlParamList);
                       
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return 0;
            }
        }

        private int RunUspGetProjectSettingsByProjectName(string projectName, EventArgsMigrationTracking e)
        {
            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                SqlParameter p_ProjectName = new SqlParameter()
                {
                    ParameterName = "@ProjectName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = projectName
                };
                sqlParamList.Add(p_ProjectName);

                SqlParameter p_SrcInstance = new SqlParameter()
                {
                    ParameterName = "@SrcInstance",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcInstance.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcInstance);

                SqlParameter p_SrcDatabase = new SqlParameter()
                {
                    ParameterName = "@SrcDatabase",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcDatabase.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcDatabase);

                SqlParameter p_SrcSchema = new SqlParameter()
                {
                    ParameterName = "@SrcSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcSchema);

                SqlParameter p_SrcTable = new SqlParameter()
                {
                    ParameterName = "@SrcTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcTable);

                SqlParameter p_SrcColumn = new SqlParameter()
                {
                    ParameterName = "@SrcColumn",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcColumn.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcColumn);

                SqlParameter p_SrcDataType = new SqlParameter()
                {
                    ParameterName = "@SrcDataType",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcDataType.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcDataType);

                SqlParameter p_SrcIndex = new SqlParameter()
                {
                    ParameterName = "@SrcIndex",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcIndex.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcIndex);


                SqlParameter p_SrcSynonym = new SqlParameter()
                {
                    ParameterName = "@SrcSynonym",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcSynonym.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcSynonym);

                SqlParameter p_TgtInstance = new SqlParameter()
                {
                    ParameterName = "@TgtInstance",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtInstance.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtInstance);

                SqlParameter p_TgtDatabase = new SqlParameter()
                {
                    ParameterName = "@TgtDatabase",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtDatabase.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtDatabase);

                SqlParameter p_TgtCurrentSchema = new SqlParameter()
                {
                    ParameterName = "@TgtCurrentSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtCurrentSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtCurrentSchema);

                SqlParameter p_TgtCurrentTable = new SqlParameter()
                {
                    ParameterName = "@TgtCurrentTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtCurrentTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtCurrentTable);

                SqlParameter p_TgtStagingSchema = new SqlParameter()
                {
                    ParameterName = "@TgtStagingSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtStagingSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtStagingSchema);

                SqlParameter p_TgtStagingTable = new SqlParameter()
                {
                    ParameterName = "@TgtStagingTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtStagingTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtStagingTable);

                SqlParameter p_TgtArchiveSchema = new SqlParameter()
                {
                    ParameterName = "@TgtArchiveSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtArchiveSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtArchiveSchema);

                SqlParameter p_TgtArchiveTable = new SqlParameter()
                {
                    ParameterName = "@TgtArchiveTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtArchiveTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtArchiveTable);

                SqlParameter p_TgtColumn = new SqlParameter()
                {
                    ParameterName = "@TgtColumn",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtColumn.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtColumn);

                SqlParameter p_TgtDataType = new SqlParameter()
                {
                    ParameterName = "@TgtDataType",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtDataType.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtDataType);

                SqlParameter p_TgtPartitionScheme = new SqlParameter()
                {
                    ParameterName = "@TgtPartitionScheme",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtPartitionScheme.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtPartitionScheme);

                SqlParameter p_TgtIndex = new SqlParameter()
                {
                    ParameterName = "@TgtIndex",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtIndex.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtIndex);

                SqlParameter p_TgtSynonym = new SqlParameter()
                {
                    ParameterName = "@TgtSynonym",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtSynonym.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtSynonym);

                SqlParameter p_TrackSynonymProjects = new SqlParameter()
                {
                    ParameterName = "@TrackSynonymProjects",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TrackSynonymProjects.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TrackSynonymProjects);

                SqlParameter p_TrackSynonymMigrationTrck = new SqlParameter()
                {
                    ParameterName = "@TrackSynonymMigrationTrck",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TrackSynonymMigrationTrck.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TrackSynonymMigrationTrck);

                e.InstanceNode.Data.Dbu.ExecuteSqlUspOutParams(e.InstanceNode, string.Concat(e.SchemaName, ".", "[usp_GetProjectSettingsFrom_", e.SchemaName, "_", e.TableName, "]")
                                                              , string.Concat("Error Executing: ", e.SchemaName, ".", "[usp_GetProjectSettingsFrom_", e.SchemaName, "_", e.TableName, "]")
                                                              , sqlParamList);
                TbxSrc.Text = string.Concat("[", p_SrcInstance.Value
                                        , "].[", p_SrcDatabase.Value
                                        , "].[", p_SrcSchema.Value
                                        , "].[", p_SrcTable.Value
                                        , "]");
                TbxTgt.Text = string.Concat("[", p_TgtInstance.Value
                                        , "].[", p_TgtDatabase.Value
                                        , "].[", p_TgtArchiveSchema.Value
                                        , "].[", p_TgtArchiveTable.Value
                                        , "]");

                //pf.SrcInstance.SetTreeNodeText(pf.SrcInstance, p_SrcInstance.Value.ToString(), false);
                //pf.SrcDatabase.SetTreeNodeText(pf.SrcDatabase, p_SrcDatabase.Value.ToString(), false);
                //pf.SrcSchema.SetTreeNodeText(pf.SrcSchema, p_SrcSchema.Value.ToString(), false);
                //pf.SrcTable.SetTreeNodeText(pf.SrcTable, p_SrcTable.Value.ToString(), false);
                //pf.SrcColumn.SetTreeNodeText(pf.SrcColumn, p_SrcColumn.Value.ToString(), false);
                //pf.SrcDataType.SetTreeNodeText(pf.SrcDataType, p_SrcDataType.Value.ToString(), false);
                //pf.SrcIndex.SetTreeNodeText(pf.SrcIndex, p_SrcIndex.Value.ToString(), false);
                //pf.SrcSynonym = p_SrcSynonym.Value.ToString();
                //pf.TgtInstance.SetTreeNodeText(pf.TgtInstance, p_TgtInstance.Value.ToString(), false);
                //pf.TgtDatabase.SetTreeNodeText(pf.TgtDatabase, p_TgtDatabase.Value.ToString(), false);
                //pf.TgtCurrentSchema.SetTreeNodeText(pf.TgtCurrentSchema, p_TgtCurrentSchema.Value.ToString(), false);
                //pf.TgtCurrentTable.SetTreeNodeText(pf.TgtCurrentTable, p_TgtCurrentTable.Value.ToString(), false);
                //pf.TgtStagingSchema.SetTreeNodeText(pf.TgtStagingSchema, p_TgtStagingSchema.Value.ToString(), false);
                //pf.TgtStagingTable.SetTreeNodeText(pf.TgtStagingTable, p_TgtStagingTable.Value.ToString(), false);
                //pf.TgtArchiveSchema.SetTreeNodeText(pf.TgtArchiveSchema, p_TgtArchiveSchema.Value.ToString(), false);
                //pf.TgtArchiveTable.SetTreeNodeText(pf.TgtArchiveTable, p_TgtArchiveTable.Value.ToString(), false);
                //pf.TgtColumn.SetTreeNodeText(pf.TgtColumn, p_TgtColumn.Value.ToString(), false);
                //pf.TgtDataType.SetTreeNodeText(pf.TgtDataType, p_TgtDataType.Value.ToString(), false);
                //pf.TgtPartitionScheme.SetTreeNodeText(pf.TgtPartitionScheme, p_TgtPartitionScheme.Value.ToString(), false);
                //pf.TgtIndex.SetTreeNodeText(pf.TgtIndex, p_TgtIndex.Value.ToString(), false);
                //pf.TgtSynonym = pf.TgtSynonym.ToString();
                //pf.TrackSynonymProjects = pf.TrackSynonymProjects.ToString();
                //pf.TrackSynonymMigrationTrck = pf.TrackSynonymMigrationTrck.ToString();

                return 1;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return 0;
            }
        }

        private bool LoadGrid(EventArgsMigrationTracking e)
        {
            bool result = false;            
            DataSetForGui ds = e.InstanceNode.Data.Dbu.GetDataSetForGui(e.InstanceNode, ProjectName.TreeNodeOwner, "MigrationTrackingTable");            
            if (ds != null)
            {
                GridTrackingTable.DataSource = ds.Ds;
                GridTrackingTable.DataMember = ds.Ds.Tables["Table"].TableName;
                GridTrackingTable.Columns["PartitionId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["PartitionNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["RowNumSrc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["RowNumTgt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["TotalMB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["UsedMB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["FilegroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["LowerPartitionBoundary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["UpperPartitionBoundary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["migrated"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Update();
                result = true;
                BtnTrackingLoadSrcCount.Image = null;
                BtnTrackingLoadSrcCount.Enabled = true;
            }
            return result;
        }

        protected virtual void OnBtnTrackingLoadSrcCountClick(object sender, EventArgs ea)
        {
            try
            {
                EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                              ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                            , ProjectsTable.TreeNodeOwner
                            , ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Database).ToString()
                            , ProjectsTable.TreeNodeOwner.Parent.ToString()
                            , ProjectsTable.TreeNodeOwner.ToString());

                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                SqlParameter p_ProjectName = new SqlParameter()
                {
                    ParameterName = "@ProjectName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = ProjectName.TreeNodeOwner.ToString()
                };
                sqlParamList.Add(p_ProjectName);


                int rowCountAffected = e.InstanceNode.Data.Dbu.ExecuteSqlUsp(e.InstanceNode
                    , string.Concat("[", e.SchemaName, "].[usp_Update_", e.SchemaName, e.TableName, Options.migrationTrackingTblSuffix, "_SrcCountPer_", ProjectName.TreeNodeOwner.ToString(), "]")
                    , sqlParamList);
            
                if (rowCountAffected > 0)
                {
                    BtnTrackingLoadSrcCount.Image = ImageList1.Images[0];
                    LoadGrid(e);

                    // create sp:
                    e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode
                    , SqlText.GetSqlCreateUspInsertIntoTargetTable(
                                                                     pf.SrcInstance.ToString()
                                                                    ,pf.SrcDatabase.ToString()
                                                                    ,pf.TgtInstance.ToString()
                                                                    ,pf.TgtDatabase.ToString()
                                                                    ,pf.TgtArchiveSchema.ToString()
                                                                    ,pf.TgtArchiveTable.ToString()
                                                                  )
                    , "Error creating GetSqlCreateUspInsertIntoTargetTable");

                    CreateUspRunMigrationProject();
                    BtnTrackingRunImport.Enabled = true;
                }
                else
                {
                    BtnTrackingLoadSrcCount.Image = ImageList1.Images[1];
                    BtnTrackingRunImport.Enabled = false;
                }
            }
            catch (ExceptionSqlExecError ex)
            {
                BtnTrackingLoadSrcCount.Image = ImageList1.Images[1];
                BtnTrackingRunImport.Enabled = false;
            }
        }

        private bool CreateUspRunMigrationProject()
        {
            try
            {
                DataSetForGui dsColListSrcTable = new DataSetForGui();
                dsColListSrcTable = pf.SrcInstance.Data.Dbu.GetDataSetForGui(pf.SrcInstance, pf.SrcColumn, null);
                dsColListSrcTable.Ds.Tables[0].Rows.RemoveAt(0);
                List<string> colListSrcTable = dsColListSrcTable.Ds.Tables[0].AsEnumerable().Select(r => r.Field<string>(1)).ToList();
                var colListSrc = String.Join("], [", colListSrcTable.ToArray());
                //Console.WriteLine(string.Concat("[", colListSrc, "]"));


                DataSetForGui dsColListTgtTable = new DataSetForGui();
                dsColListTgtTable = pf.TgtInstance.Data.Dbu.GetDataSetForGui(pf.TgtInstance, pf.TgtColumn, null);
                dsColListTgtTable.Ds.Tables[0].Rows.RemoveAt(0);
                List<string> colListTgtTable = dsColListTgtTable.Ds.Tables[0].AsEnumerable().Select(r => r.Field<string>(1)).ToList();
                var colListTgt = String.Join("], [", colListSrcTable.ToArray());
                //colListVar.Remove(0);
                //Console.WriteLine(string.Concat("[", colListTgt, "]"));

                string usp_RunMigrationProject = SqlText.GetSqlRunMigrationProject(
                                              ProjectName.TreeNodeOwner.ToString()
                                            , ProjectsTable.TreeNodeOwner.Parent.ToString()
                                            , ProjectsTable.TreeNodeOwner.ToString()
                                            , pf_new.TgtDatabase
                                            , pf_new.TgtArchiveSchema
                                            , pf_new.TgtCurrentSchema
                                            , pf_new.TgtArchiveTable
                                            , pf_new.TgtCurrentTable
                                            , string.Concat("[", colListTgt, "]")
                                            , string.Concat("[", colListTgt, "]")
                                            , string.Concat("[", colListSrc, "]")
                                            , pf_new.SrcInstance
                                            , pf_new.SrcDatabase
                                            , pf_new.SrcSchema
                                            , pf_new.SrcTable
                                            , pf_new.SrcColumn

                    );
                EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                                      ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                    , ProjectsTable.TreeNodeOwner
                                    , ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Database).ToString()
                                    , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                                    , ProjectsTable.TreeNodeOwner.Data.ObjectText);
                
                
                e.InstanceNode.Data.Dbu.ExecuteSqlNonQuery(e.InstanceNode, usp_RunMigrationProject, "Error creating usp_RunMigrationProject");

                return true;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }
    }
}
