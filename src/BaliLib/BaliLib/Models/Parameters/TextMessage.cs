using System.Collections.Generic;

namespace BaleLib.Models.Parameters
{
    public class TextMessage : BaseInput
    {
        public string Text { get; set; }
        public ReplyKeyboard ReplyMarkup { get; set; }
    }

    public class ReplyKeyboard
    {
        public IEnumerable<IEnumerable<InlineKeyboardItem>> InlineKeyboard { get; set; }
        public static ReplyKeyboardBuidler Create()
        {
            return new ReplyKeyboardBuidler();
        }
    }

    public class ReplyKeyboardBuidler
    {
        List<List<InlineKeyboardItem>> _inlineKeyboard;
        List<InlineKeyboardItem> _row;
        public ReplyKeyboardBuidler()
        {
            _inlineKeyboard = new List<List<InlineKeyboardItem>>();
            _row = new List<InlineKeyboardItem>();
        }

        public ReplyKeyboardBuidler AddButton(string text)
        {
            _row.Add(new InlineKeyboardItem(text));
            return this;
        }

        //public ReplyKeyboardBuidler AddRow()
        //{
        //    if (_row.Count > 0)
        //        _inlineKeyboard.Add(_row);

        //    _row = new List<InlineKeyboardItem>();
        //    return this;
        //}

        public ReplyKeyboard Build()
        {
            if (_row.Count > 0)
                _inlineKeyboard.Add(_row);

            ReplyKeyboard keyboard = new ReplyKeyboard()
            {
                InlineKeyboard = _inlineKeyboard
            };

            return keyboard;
        }


    }

    public class InlineKeyboardItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string CallbackData { get; set; }
        public string SwitchInlineQuery { get; set; }
        public string SwitchInlineQueryCurrentChat { get; set; }

        //public inlinekeyboarditem()
        //{
        //    callbackdata = "inlinekeyboarditem_default_value";
        //}

        public InlineKeyboardItem(string text) //: this()
        {
            Text = text;
            CallbackData = text;
        }
    }
}
