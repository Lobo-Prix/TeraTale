﻿using System.Collections.Generic;

public class Nox : NPC
{
    protected override List<Script> scripts
    {
        get
        {
            List<Script> _scripts = new List<Script>();

            Script s;
            Script.Command cmd;

            s.commands = new List<Script.Command>();
            s.comment = "안녕, 무슨일이니?";
            cmd.name = "대화하기";
            cmd.action = () =>
            {
                s.commands = new List<Script.Command>();
                s.comment = "음, 딱히 할 말이 없네.";
                cmd.name = "나가기";
                cmd.action = () => { NPCDialog.instance.Close(true); };
                s.commands.Add(cmd);
                _scripts.Add(s);

                NPCDialog.instance.Next();
            };
            s.commands.Add(cmd);
            cmd.name = "퀘스트";
            cmd.action = () =>
            {
                s.commands = new List<Script.Command>();
                s.comment = "요즘 우리 과수원에 좀비들이 자주 출몰해서 사과농사를 망치고있어. 좀비들이 훔쳐간 사과 10개를 되찾아와 주겠니? 보상으로 포션 8개를 줄게.";
                cmd.name = "수락";
                cmd.action = () =>
                {
                    s.commands = new List<Script.Command>();
                    s.comment = "그럼, 꼭 좀 부탁할게, 고마워!";
                    cmd.name = "나가기";
                    cmd.action = () => { NPCDialog.instance.Close(true); };
                    s.commands.Add(cmd);
                    _scripts.Add(s);

                    NPCDialog.instance.Next();
                };
                s.commands.Add(cmd);
                cmd.name = "거절";
                cmd.action = () =>
                {
                    s.commands = new List<Script.Command>();
                    s.comment = "그래? 아쉽지만 다른친구에게 부탁해봐야겠네 으으...";
                    cmd.name = "나가기";
                    cmd.action = () => { NPCDialog.instance.Close(true); };
                    s.commands.Add(cmd);
                    _scripts.Add(s);

                    NPCDialog.instance.Next();
                };
                s.commands.Add(cmd);
                _scripts.Add(s);

                NPCDialog.instance.Next();
            };
            s.commands.Add(cmd);
            _scripts.Add(s);

            return _scripts;
        }
    }
}