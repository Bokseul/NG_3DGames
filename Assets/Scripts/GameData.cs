using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    Dictionary<string, SkillData> mSkillList = new Dictionary<string, SkillData>();

    //---------------------------------------------------
    public void Init()
    {
        CSVReader.Table skillDataTable = CSVReader.Reader.ReadCSVToTable("Datas/SkillDataTable");
        mSkillList = skillDataTable.TableToDictionary<string,SkillData>();

        Debug.Log("Succeeded GameData::Init()");
    }
}
