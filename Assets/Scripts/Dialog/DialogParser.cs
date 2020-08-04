using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogParser : MonoBehaviour
{
    public Dialog[] Parse(string _CSVFileName)
    {
        List<Dialog> dialogList = new List<Dialog>(); //대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); // csv파일 가져옴.

        string[] data = csvData.text.Split(new char[] { '\n' }); //데이터를 엔터 단위로 쪼갬.

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] {','}); //쪼개진 데이터를 쉼표 단위로 쪼갬.

            Dialog dialog = new Dialog(); //데이터를 담을 Dialog 를 선언.

            dialog.name = row[1]; // Dialog의 네임 부여

            List<string> contextList = new List<string>(); // Dialog의 콘텍스트 리스트 부여. (ID가 공백인동안 반복)
            do
            {
                contextList.Add(row[2]);
                if(++i < data.Length)
                {
                    row = data[i].Split(new char[]{','});
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");

            dialog.contexts = contextList.ToArray();

            dialogList.Add(dialog);
        }

        return dialogList.ToArray();
    }
}
