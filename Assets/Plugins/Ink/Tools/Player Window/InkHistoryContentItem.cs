using System;
using Ink.Runtime;
using UnityEngine;

namespace Ink.UnityIntegration.Debugging {
    [System.Serializable]
    public class InkHistoryContentItem {
        public enum ContentType {
            PresentedContent,
            ChooseChoice,
            PresentedChoice,
            EvaluateFunction,
            CompleteEvaluateFunction,
            ChoosePathString,
            Warning,
            Error,
            DebugNote
        }

        public string content;
        public ContentType contentType;
        [SerializeField]
        JsonDateTime _time;
        public DateTime time {
            get {
                return _time;
            } private set {
                _time = value;
            }
        }

        InkHistoryContentItem (string text, ContentType contentType) {
            this.content = text;
            this.contentType = contentType;
            this.time = DateTime.Now;
        }

        public static InkHistoryContentItem CreateForContent (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.PresentedContent);
        }
        public static InkHistoryContentItem CreateForPresentChoice (Choice choice) {
            return new InkHistoryContentItem(choice.text.Trim(), InkHistoryContentItem.ContentType.PresentedChoice);
        }
        public static InkHistoryContentItem CreateForMakeChoice (Choice choice) {
            return new InkHistoryContentItem(choice.text.Trim(), InkHistoryContentItem.ContentType.ChooseChoice);
        }
        public static InkHistoryContentItem CreateForEvaluateFunction (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.EvaluateFunction);
        }
        public static InkHistoryContentItem CreateForCompleteEvaluateFunction (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.CompleteEvaluateFunction);
        }
        public static InkHistoryContentItem CreateForChoosePathString (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.ChoosePathString);
        }
        public static InkHistoryContentItem CreateForWarning (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.Warning);
        }
        public static InkHistoryContentItem CreateForError (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.Error);
        }
        public static InkHistoryContentItem CreateForDebugNote (string choiceText) {
            return new InkHistoryContentItem(choiceText, InkHistoryContentItem.ContentType.DebugNote);
        }
        
        struct JsonDateTime {
            public long value;
            public static implicit operator DateTime(JsonDateTime jdt) {
                return DateTime.FromFileTimeUtc(jdt.value);
            }
            public static implicit operator JsonDateTime(DateTime dt) {
                JsonDateTime jdt = new JsonDateTime();
                jdt.value = dt.ToFileTimeUtc();
                return jdt;
            }
        }
    }
}