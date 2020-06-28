using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadEmulator
{
    public class ScantiliaGateway : IScintillaGateway
    {
        List<IntPtr> FakeWindowHandles = new List<IntPtr>();
        public ScantiliaGateway()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 3; i++)
            {
                FakeWindowHandles.Add(new IntPtr(rnd.Next(452545, 7752545)));
            }
        }
        public void AddRefDocument(int doc)
        {
            throw new NotImplementedException();
        }

        public int AddSelection(int caret, int anchor)
        {
            throw new NotImplementedException();
        }

        public void AddStyledText(int length, Cells c)
        {
            throw new NotImplementedException();
        }

        public void AddTabStop(int line, int x)
        {
            throw new NotImplementedException();
        }

        public void AddText(int length, string text)
        {

        }

        public void AddUndoAction(int token, int flags)
        {
            throw new NotImplementedException();
        }

        public void Allocate(int bytes)
        {
            throw new NotImplementedException();
        }

        public int AllocateExtendedStyles(int numberStyles)
        {
            throw new NotImplementedException();
        }

        public int AllocateSubStyles(int styleBase, int numberStyles)
        {
            throw new NotImplementedException();
        }

        public void AnnotationClearAll()
        {
            throw new NotImplementedException();
        }

        public int AnnotationGetLines(int line)
        {
            throw new NotImplementedException();
        }

        public int AnnotationGetStyle(int line)
        {
            throw new NotImplementedException();
        }

        public int AnnotationGetStyleOffset()
        {
            throw new NotImplementedException();
        }

        public string AnnotationGetStyles(int line)
        {
            throw new NotImplementedException();
        }

        public string AnnotationGetText(int line)
        {
            throw new NotImplementedException();
        }

        public int AnnotationGetVisible()
        {
            throw new NotImplementedException();
        }

        public void AnnotationSetStyle(int line, int style)
        {
            throw new NotImplementedException();
        }

        public void AnnotationSetStyleOffset(int style)
        {
            throw new NotImplementedException();
        }

        public void AnnotationSetStyles(int line, string styles)
        {
            throw new NotImplementedException();
        }

        public void AnnotationSetText(int line, string text)
        {
            throw new NotImplementedException();
        }

        public void AnnotationSetVisible(int visible)
        {
            throw new NotImplementedException();
        }

        public void AppendText(int length, string text)
        {
            throw new NotImplementedException();
        }

        public void AppendTextAndMoveCursor(string text)
        {
            throw new NotImplementedException();
        }

        public void AssignCmdKey(KeyModifier km, int msg)
        {
            throw new NotImplementedException();
        }

        public bool AutoCActive()
        {
            throw new NotImplementedException();
        }

        public void AutoCCancel()
        {
            throw new NotImplementedException();
        }

        public void AutoCComplete()
        {
            throw new NotImplementedException();
        }

        public bool AutoCGetAutoHide()
        {
            throw new NotImplementedException();
        }

        public bool AutoCGetCancelAtStart()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetCaseInsensitiveBehaviour()
        {
            throw new NotImplementedException();
        }

        public bool AutoCGetChooseSingle()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetCurrent()
        {
            throw new NotImplementedException();
        }

        public string AutoCGetCurrentText()
        {
            throw new NotImplementedException();
        }

        public bool AutoCGetDropRestOfWord()
        {
            throw new NotImplementedException();
        }

        public bool AutoCGetIgnoreCase()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetMaxHeight()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetMaxWidth()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetMulti()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetOrder()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetSeparator()
        {
            throw new NotImplementedException();
        }

        public int AutoCGetTypeSeparator()
        {
            throw new NotImplementedException();
        }

        public Position AutoCPosStart()
        {
            throw new NotImplementedException();
        }

        public void AutoCSelect(string text)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetAutoHide(bool autoHide)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetCancelAtStart(bool cancel)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetCaseInsensitiveBehaviour(int behaviour)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetChooseSingle(bool chooseSingle)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetDropRestOfWord(bool dropRestOfWord)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetFillUps(string characterSet)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetIgnoreCase(bool ignoreCase)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetMaxHeight(int rowCount)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetMaxWidth(int characterCount)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetMulti(int multi)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetOrder(int order)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetSeparator(int separatorCharacter)
        {
            throw new NotImplementedException();
        }

        public void AutoCSetTypeSeparator(int separatorCharacter)
        {
            throw new NotImplementedException();
        }

        public void AutoCShow(int lenEntered, string itemList)
        {
            throw new NotImplementedException();
        }

        public void AutoCStops(string characterSet)
        {
            throw new NotImplementedException();
        }

        public void BackTab()
        {
            throw new NotImplementedException();
        }

        public void BeginUndoAction()
        {
            throw new NotImplementedException();
        }

        public void BraceBadLight(Position pos)
        {
            throw new NotImplementedException();
        }

        public void BraceBadLightIndicator(bool useBraceBadLightIndicator, int indicator)
        {
            throw new NotImplementedException();
        }

        public void BraceHighlight(Position pos1, Position pos2)
        {
            throw new NotImplementedException();
        }

        public void BraceHighlightIndicator(bool useBraceHighlightIndicator, int indicator)
        {
            throw new NotImplementedException();
        }

        public Position BraceMatch(Position pos)
        {
            throw new NotImplementedException();
        }

        public bool CallTipActive()
        {
            throw new NotImplementedException();
        }

        public void CallTipCancel()
        {
            throw new NotImplementedException();
        }

        public Position CallTipPosStart()
        {
            throw new NotImplementedException();
        }

        public void CallTipSetBack(Colour back)
        {
            throw new NotImplementedException();
        }

        public void CallTipSetFore(Colour fore)
        {
            throw new NotImplementedException();
        }

        public void CallTipSetForeHlt(Colour fore)
        {
            throw new NotImplementedException();
        }

        public void CallTipSetHlt(int start, int end)
        {
            throw new NotImplementedException();
        }

        public void CallTipSetPosition(bool above)
        {
            throw new NotImplementedException();
        }

        public void CallTipSetPosStart(int posStart)
        {
            throw new NotImplementedException();
        }

        public void CallTipShow(Position pos, string definition)
        {
            throw new NotImplementedException();
        }

        public void CallTipUseStyle(int tabSize)
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public bool CanPaste()
        {
            throw new NotImplementedException();
        }

        public bool CanRedo()
        {
            throw new NotImplementedException();
        }

        public bool CanUndo()
        {
            throw new NotImplementedException();
        }

        public void ChangeInsertion(int length, string text)
        {
            throw new NotImplementedException();
        }

        public int ChangeLexerState(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public void CharLeft()
        {
            throw new NotImplementedException();
        }

        public void CharLeftExtend()
        {
            throw new NotImplementedException();
        }

        public void CharLeftRectExtend()
        {
            throw new NotImplementedException();
        }

        public Position CharPositionFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Position CharPositionFromPointClose(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void CharRight()
        {
            throw new NotImplementedException();
        }

        public void CharRightExtend()
        {
            throw new NotImplementedException();
        }

        public void CharRightRectExtend()
        {
            throw new NotImplementedException();
        }

        public void ChooseCaretX()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            // TODO:
        }

        public void ClearAllCmdKeys()
        {
            throw new NotImplementedException();
        }

        public void ClearCmdKey(KeyModifier km)
        {
            throw new NotImplementedException();
        }

        public void ClearDocumentStyle()
        {
            throw new NotImplementedException();
        }

        public void ClearRegisteredImages()
        {
            throw new NotImplementedException();
        }

        public void ClearRepresentation(string encodedCharacter)
        {
            throw new NotImplementedException();
        }

        public void ClearSelections()
        {
            throw new NotImplementedException();
        }

        public void ClearSelectionToCursor()
        {
            throw new NotImplementedException();
        }

        public void ClearTabStops(int line)
        {
            throw new NotImplementedException();
        }

        public void Colourise(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public int ContractedFoldNext(int lineStart)
        {
            throw new NotImplementedException();
        }

        public void ConvertEOLs(int eolMode)
        {
            throw new NotImplementedException();
        }

        public void Copy()
        {
            throw new NotImplementedException();
        }

        public void CopyAllowLine()
        {
            throw new NotImplementedException();
        }

        public void CopyRange(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public void CopyText(int length, string text)
        {
            throw new NotImplementedException();
        }

        public int CountCharacters(int startPos, int endPos)
        {
            throw new NotImplementedException();
        }

        public int CreateDocument()
        {
            throw new NotImplementedException();
        }

        public int CreateLoader(int bytes)
        {
            throw new NotImplementedException();
        }

        public void Cut()
        {
            throw new NotImplementedException();
        }

        public void DeleteBack()
        {
            throw new NotImplementedException();
        }

        public void DeleteBackNotLine()
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(Position pos, int deleteLength)
        {
            throw new NotImplementedException();
        }

        public void DelLineLeft()
        {
            throw new NotImplementedException();
        }

        public void DelLineRight()
        {
            throw new NotImplementedException();
        }

        public void DelWordLeft()
        {
            throw new NotImplementedException();
        }

        public void DelWordRight()
        {
            throw new NotImplementedException();
        }

        public void DelWordRightEnd()
        {
            throw new NotImplementedException();
        }

        public string DescribeKeyWordSets()
        {
            throw new NotImplementedException();
        }

        public string DescribeProperty(string name)
        {
            throw new NotImplementedException();
        }

        public int DistanceToSecondaryStyles()
        {
            throw new NotImplementedException();
        }

        public int DocLineFromVisible(int lineDisplay)
        {
            throw new NotImplementedException();
        }

        public void DocumentEnd()
        {
            throw new NotImplementedException();
        }

        public void DocumentEndExtend()
        {
            throw new NotImplementedException();
        }

        public void DocumentStart()
        {
            throw new NotImplementedException();
        }

        public void DocumentStartExtend()
        {
            throw new NotImplementedException();
        }

        public void DropSelectionN(int selection)
        {
            throw new NotImplementedException();
        }

        public void EditToggleOvertype()
        {
            throw new NotImplementedException();
        }

        public void EmptyUndoBuffer()
        {
            throw new NotImplementedException();
        }

        public string EncodedFromUTF8(string utf8)
        {
            throw new NotImplementedException();
        }

        public void EndUndoAction()
        {
            throw new NotImplementedException();
        }

        public void EnsureVisible(int line)
        {
            throw new NotImplementedException();
        }

        public void EnsureVisibleEnforcePolicy(int line)
        {
            throw new NotImplementedException();
        }

        public void ExpandChildren(int line, int level)
        {
            throw new NotImplementedException();
        }

        public int FindColumn(int line, int column)
        {
            throw new NotImplementedException();
        }

        public void FindIndicatorFlash(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public void FindIndicatorHide()
        {
            throw new NotImplementedException();
        }

        public void FindIndicatorShow(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public Position FindText(int flags, TextToFind ft)
        {
            throw new NotImplementedException();
        }

        public void FoldAll(int action)
        {
            throw new NotImplementedException();
        }

        public void FoldChildren(int line, int action)
        {
            throw new NotImplementedException();
        }

        public void FoldLine(int line, int action)
        {
            throw new NotImplementedException();
        }

        public void FormFeed()
        {
            throw new NotImplementedException();
        }

        public void FreeSubStyles()
        {
            throw new NotImplementedException();
        }

        public Colour GetAdditionalCaretFore()
        {
            throw new NotImplementedException();
        }

        public bool GetAdditionalCaretsBlink()
        {
            throw new NotImplementedException();
        }

        public bool GetAdditionalCaretsVisible()
        {
            throw new NotImplementedException();
        }

        public int GetAdditionalSelAlpha()
        {
            throw new NotImplementedException();
        }

        public bool GetAdditionalSelectionTyping()
        {
            throw new NotImplementedException();
        }

        public bool GetAllLinesVisible()
        {
            throw new NotImplementedException();
        }

        public Position GetAnchor()
        {
            throw new NotImplementedException();
        }

        public int GetAutomaticFold()
        {
            throw new NotImplementedException();
        }

        public bool GetBackSpaceUnIndents()
        {
            throw new NotImplementedException();
        }

        public bool GetBufferedDraw()
        {
            throw new NotImplementedException();
        }

        public Colour GetCaretFore()
        {
            throw new NotImplementedException();
        }

        public Colour GetCaretLineBack()
        {
            throw new NotImplementedException();
        }

        public int GetCaretLineBackAlpha()
        {
            throw new NotImplementedException();
        }

        public bool GetCaretLineVisible()
        {
            throw new NotImplementedException();
        }

        public bool GetCaretLineVisibleAlways()
        {
            throw new NotImplementedException();
        }

        public int GetCaretPeriod()
        {
            throw new NotImplementedException();
        }

        public int GetCaretSticky()
        {
            throw new NotImplementedException();
        }

        public int GetCaretStyle()
        {
            throw new NotImplementedException();
        }

        public int GetCaretWidth()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetCharacterPointer()
        {
            throw new NotImplementedException();
        }

        public int GetCharAt(Position pos)
        {
            throw new NotImplementedException();
        }

        public int GetCodePage()
        {
            throw new NotImplementedException();
        }

        public int GetColumn(Position pos)
        {
            throw new NotImplementedException();
        }

        public int GetControlCharSymbol()
        {
            throw new NotImplementedException();
        }

        public string GetCurLine(int length)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentLineNumber()
        {
            throw new NotImplementedException();
        }

        public Position GetCurrentPos()
        {
            throw new NotImplementedException();
        }

        public int GetCursor()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetDirectFunction()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetDirectPointer()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetDocPointer()
        {
            Random rnd = new Random(DateTime.Now.Second);
            var ptr = FakeWindowHandles[rnd.Next(0, 2)];
            return ptr;
        }

        public Colour GetEdgeColour()
        {
            throw new NotImplementedException();
        }

        public int GetEdgeColumn()
        {
            throw new NotImplementedException();
        }

        public int GetEdgeMode()
        {
            throw new NotImplementedException();
        }

        public bool GetEndAtLastLine()
        {
            throw new NotImplementedException();
        }

        public Position GetEndStyled()
        {
            throw new NotImplementedException();
        }

        public int GetEOLMode()
        {
            throw new NotImplementedException();
        }

        public int GetExtraAscent()
        {
            throw new NotImplementedException();
        }

        public int GetExtraDescent()
        {
            throw new NotImplementedException();
        }

        public int GetFirstVisibleLine()
        {
            throw new NotImplementedException();
        }

        public bool GetFocus()
        {
            throw new NotImplementedException();
        }

        public bool GetFoldExpanded(int line)
        {
            throw new NotImplementedException();
        }

        public int GetFoldLevel(int line)
        {
            throw new NotImplementedException();
        }

        public int GetFoldParent(int line)
        {
            throw new NotImplementedException();
        }

        public int GetFontQuality()
        {
            throw new NotImplementedException();
        }

        public Position GetGapPosition()
        {
            throw new NotImplementedException();
        }

        public int GetHighlightGuide()
        {
            throw new NotImplementedException();
        }

        public Colour GetHotspotActiveBack()
        {
            throw new NotImplementedException();
        }

        public Colour GetHotspotActiveFore()
        {
            throw new NotImplementedException();
        }

        public bool GetHotspotActiveUnderline()
        {
            throw new NotImplementedException();
        }

        public bool GetHotspotSingleLine()
        {
            throw new NotImplementedException();
        }

        public bool GetHScrollBar()
        {
            throw new NotImplementedException();
        }

        public int GetIdentifier()
        {
            throw new NotImplementedException();
        }

        public int GetIMEInteraction()
        {
            throw new NotImplementedException();
        }

        public int GetIndent()
        {
            throw new NotImplementedException();
        }

        public int GetIndentationGuides()
        {
            throw new NotImplementedException();
        }

        public int GetIndicatorCurrent()
        {
            throw new NotImplementedException();
        }

        public int GetIndicatorValue()
        {
            throw new NotImplementedException();
        }

        public bool GetKeysUnicode()
        {
            throw new NotImplementedException();
        }

        public int GetLastChild(int line, int level)
        {
            throw new NotImplementedException();
        }

        public int GetLayoutCache()
        {
            throw new NotImplementedException();
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public int GetLexer()
        {
            throw new NotImplementedException();
        }

        public string GetLexerLanguage()
        {
            throw new NotImplementedException();
        }

        public string GetLine(int line)
        {
            throw new NotImplementedException();
        }

        public int GetLineCount()
        {
            throw new NotImplementedException();
        }

        public Position GetLineEndPosition(int line)
        {
            throw new NotImplementedException();
        }

        public int GetLineEndTypesActive()
        {
            throw new NotImplementedException();
        }

        public int GetLineEndTypesAllowed()
        {
            throw new NotImplementedException();
        }

        public int GetLineEndTypesSupported()
        {
            throw new NotImplementedException();
        }

        public int GetLineIndentation(int line)
        {
            throw new NotImplementedException();
        }

        public Position GetLineIndentPosition(int line)
        {
            throw new NotImplementedException();
        }

        public Position GetLineSelEndPosition(int line)
        {
            throw new NotImplementedException();
        }

        public Position GetLineSelStartPosition(int line)
        {
            throw new NotImplementedException();
        }

        public int GetLineState(int line)
        {
            throw new NotImplementedException();
        }

        public bool GetLineVisible(int line)
        {
            throw new NotImplementedException();
        }

        public int GetMainSelection()
        {
            throw new NotImplementedException();
        }

        public int GetMarginCursorN(int margin)
        {
            throw new NotImplementedException();
        }

        public int GetMarginLeft()
        {
            throw new NotImplementedException();
        }

        public int GetMarginMaskN(int margin)
        {
            throw new NotImplementedException();
        }

        public int GetMarginOptions()
        {
            throw new NotImplementedException();
        }

        public int GetMarginRight()
        {
            throw new NotImplementedException();
        }

        public bool GetMarginSensitiveN(int margin)
        {
            throw new NotImplementedException();
        }

        public int GetMarginTypeN(int margin)
        {
            throw new NotImplementedException();
        }

        public int GetMarginWidthN(int margin)
        {
            throw new NotImplementedException();
        }

        public int GetMaxLineState()
        {
            throw new NotImplementedException();
        }

        public int GetModEventMask()
        {
            throw new NotImplementedException();
        }

        public bool GetModify()
        {
            throw new NotImplementedException();
        }

        public bool GetMouseDownCaptures()
        {
            throw new NotImplementedException();
        }

        public int GetMouseDwellTime()
        {
            throw new NotImplementedException();
        }

        public bool GetMouseSelectionRectangularSwitch()
        {
            throw new NotImplementedException();
        }

        public int GetMultiPaste()
        {
            throw new NotImplementedException();
        }

        public bool GetMultipleSelection()
        {
            throw new NotImplementedException();
        }

        public int GetNextTabStop(int line, int x)
        {
            throw new NotImplementedException();
        }

        public bool GetOvertype()
        {
            throw new NotImplementedException();
        }

        public bool GetPasteConvertEndings()
        {
            throw new NotImplementedException();
        }

        public int GetPhasesDraw()
        {
            throw new NotImplementedException();
        }

        public int GetPositionCache()
        {
            throw new NotImplementedException();
        }

        public int GetPrimaryStyleFromStyle(int style)
        {
            throw new NotImplementedException();
        }

        public int GetPrintColourMode()
        {
            throw new NotImplementedException();
        }

        public int GetPrintMagnification()
        {
            throw new NotImplementedException();
        }

        public int GetPrintWrapMode()
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string key)
        {
            throw new NotImplementedException();
        }

        public string GetPropertyExpanded(string key)
        {
            throw new NotImplementedException();
        }

        public int GetPropertyInt(string key)
        {
            throw new NotImplementedException();
        }

        public string GetPunctuationChars()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetRangePointer(int position, int rangeLength)
        {
            throw new NotImplementedException();
        }

        public bool GetReadOnly()
        {
            throw new NotImplementedException();
        }

        public Position GetRectangularSelectionAnchor()
        {
            throw new NotImplementedException();
        }

        public int GetRectangularSelectionAnchorVirtualSpace()
        {
            throw new NotImplementedException();
        }

        public Position GetRectangularSelectionCaret()
        {
            throw new NotImplementedException();
        }

        public int GetRectangularSelectionCaretVirtualSpace()
        {
            throw new NotImplementedException();
        }

        public int GetRectangularSelectionModifier()
        {
            throw new NotImplementedException();
        }

        public string GetRepresentation(string encodedCharacter)
        {
            throw new NotImplementedException();
        }

        public Win32.ScrollInfo GetScrollInfo(Win32.ScrollInfoMask mask = Win32.ScrollInfoMask.SIF_ALL, Win32.ScrollInfoBar scrollBar = Win32.ScrollInfoBar.SB_BOTH)
        {
            throw new NotImplementedException();
        }

        public int GetScrollWidth()
        {
            throw new NotImplementedException();
        }

        public bool GetScrollWidthTracking()
        {
            throw new NotImplementedException();
        }

        public int GetSearchFlags()
        {
            throw new NotImplementedException();
        }

        public int GetSelAlpha()
        {
            throw new NotImplementedException();
        }

        public bool GetSelectionEmpty()
        {
            throw new NotImplementedException();
        }

        public Position GetSelectionEnd()
        {
            throw new NotImplementedException();
        }

        public int GetSelectionLength()
        {
            throw new NotImplementedException();
        }

        public int GetSelectionMode()
        {
            throw new NotImplementedException();
        }

        public Position GetSelectionNAnchor(int selection)
        {
            throw new NotImplementedException();
        }

        public int GetSelectionNAnchorVirtualSpace(int selection)
        {
            throw new NotImplementedException();
        }

        public Position GetSelectionNCaret(int selection)
        {
            throw new NotImplementedException();
        }

        public int GetSelectionNCaretVirtualSpace(int selection)
        {
            throw new NotImplementedException();
        }

        public Position GetSelectionNEnd(int selection)
        {
            throw new NotImplementedException();
        }

        public Position GetSelectionNStart(int selection)
        {
            throw new NotImplementedException();
        }

        public int GetSelections()
        {
            throw new NotImplementedException();
        }

        public Position GetSelectionStart()
        {
            throw new NotImplementedException();
        }

        public bool GetSelEOLFilled()
        {
            throw new NotImplementedException();
        }

        public string GetSelText()
        {
            throw new NotImplementedException();
        }

        public int GetStatus()
        {
            throw new NotImplementedException();
        }

        public int GetStyleAt(Position pos)
        {
            throw new NotImplementedException();
        }

        public int GetStyleBits()
        {
            throw new NotImplementedException();
        }

        public int GetStyleBitsNeeded()
        {
            throw new NotImplementedException();
        }

        public int GetStyledText(TextRange tr)
        {
            throw new NotImplementedException();
        }

        public int GetStyleFromSubStyle(int subStyle)
        {
            throw new NotImplementedException();
        }

        public string GetSubStyleBases()
        {
            throw new NotImplementedException();
        }

        public int GetSubStylesLength(int styleBase)
        {
            throw new NotImplementedException();
        }

        public int GetSubStylesStart(int styleBase)
        {
            throw new NotImplementedException();
        }

        public bool GetTabIndents()
        {
            throw new NotImplementedException();
        }

        public int GetTabWidth()
        {
            throw new NotImplementedException();
        }

        public string GetTag(int tagNumber)
        {
            throw new NotImplementedException();
        }

        public Position GetTargetEnd()
        {
            throw new NotImplementedException();
        }

        public Position GetTargetStart()
        {
            throw new NotImplementedException();
        }

        public string GetTargetText()
        {
            throw new NotImplementedException();
        }

        public int GetTechnology()
        {
            throw new NotImplementedException();
        }

        public string GetText(int length)
        {
            throw new NotImplementedException();
        }

        public int GetTextLength()
        {
            throw new NotImplementedException();
        }

        public int GetTextRange(TextRange tr)
        {
            throw new NotImplementedException();
        }

        public bool GetTwoPhaseDraw()
        {
            throw new NotImplementedException();
        }

        public bool GetUndoCollection()
        {
            throw new NotImplementedException();
        }

        public bool GetUsePalette()
        {
            throw new NotImplementedException();
        }

        public bool GetUseTabs()
        {
            throw new NotImplementedException();
        }

        public bool GetViewEOL()
        {
            throw new NotImplementedException();
        }

        public int GetViewWS()
        {
            throw new NotImplementedException();
        }

        public int GetVirtualSpaceOptions()
        {
            throw new NotImplementedException();
        }

        public bool GetVScrollBar()
        {
            throw new NotImplementedException();
        }

        public string GetWhitespaceChars()
        {
            throw new NotImplementedException();
        }

        public int GetWhitespaceSize()
        {
            throw new NotImplementedException();
        }

        public string GetWordChars()
        {
            throw new NotImplementedException();
        }

        public int GetWrapIndentMode()
        {
            throw new NotImplementedException();
        }

        public int GetWrapMode()
        {
            throw new NotImplementedException();
        }

        public int GetWrapStartIndent()
        {
            throw new NotImplementedException();
        }

        public int GetWrapVisualFlags()
        {
            throw new NotImplementedException();
        }

        public int GetWrapVisualFlagsLocation()
        {
            throw new NotImplementedException();
        }

        public int GetXOffset()
        {
            throw new NotImplementedException();
        }

        public int GetZoom()
        {
            throw new NotImplementedException();
        }

        public void GotoLine(int line)
        {
            throw new NotImplementedException();
        }

        public void GotoPos(Position pos)
        {
            throw new NotImplementedException();
        }

        public void GrabFocus()
        {
            throw new NotImplementedException();
        }

        public void HideLines(int lineStart, int lineEnd)
        {
            throw new NotImplementedException();
        }

        public void HideSelection(bool normal)
        {
            throw new NotImplementedException();
        }

        public void Home()
        {
            throw new NotImplementedException();
        }

        public void HomeDisplay()
        {
            throw new NotImplementedException();
        }

        public void HomeDisplayExtend()
        {
            throw new NotImplementedException();
        }

        public void HomeExtend()
        {
            throw new NotImplementedException();
        }

        public void HomeRectExtend()
        {
            throw new NotImplementedException();
        }

        public void HomeWrap()
        {
            throw new NotImplementedException();
        }

        public void HomeWrapExtend()
        {
            throw new NotImplementedException();
        }

        public int IndicatorAllOnFor(int position)
        {
            throw new NotImplementedException();
        }

        public void IndicatorClearRange(int position, int clearLength)
        {
            throw new NotImplementedException();
        }

        public int IndicatorEnd(int indicator, int position)
        {
            throw new NotImplementedException();
        }

        public void IndicatorFillRange(int position, int fillLength)
        {
            throw new NotImplementedException();
        }

        public int IndicatorStart(int indicator, int position)
        {
            throw new NotImplementedException();
        }

        public int IndicatorValueAt(int indicator, int position)
        {
            throw new NotImplementedException();
        }

        public int IndicGetAlpha(int indicator)
        {
            throw new NotImplementedException();
        }

        public int IndicGetFlags(int indic)
        {
            throw new NotImplementedException();
        }

        public Colour IndicGetFore(int indic)
        {
            throw new NotImplementedException();
        }

        public Colour IndicGetHoverFore(int indic)
        {
            throw new NotImplementedException();
        }

        public int IndicGetHoverStyle(int indic)
        {
            throw new NotImplementedException();
        }

        public int IndicGetOutlineAlpha(int indicator)
        {
            throw new NotImplementedException();
        }

        public int IndicGetStyle(int indic)
        {
            throw new NotImplementedException();
        }

        public bool IndicGetUnder(int indic)
        {
            throw new NotImplementedException();
        }

        public void IndicSetAlpha(int indicator, int alpha)
        {
            throw new NotImplementedException();
        }

        public void IndicSetFlags(int indic, int flags)
        {
            throw new NotImplementedException();
        }

        public void IndicSetFore(int indic, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void IndicSetHoverFore(int indic, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void IndicSetHoverStyle(int indic, int style)
        {
            throw new NotImplementedException();
        }

        public void IndicSetOutlineAlpha(int indicator, int alpha)
        {
            throw new NotImplementedException();
        }

        public void IndicSetStyle(int indic, int style)
        {
            throw new NotImplementedException();
        }

        public void IndicSetUnder(int indic, bool under)
        {
            throw new NotImplementedException();
        }

        public void InsertText(Position pos, string text)
        {
            throw new NotImplementedException();
        }

        public void InsertTextAndMoveCursor(string text)
        {
            throw new NotImplementedException();
        }

        public void LineCopy()
        {
            throw new NotImplementedException();
        }

        public void LineCut()
        {
            throw new NotImplementedException();
        }

        public void LineDelete()
        {
            throw new NotImplementedException();
        }

        public void LineDown()
        {
            throw new NotImplementedException();
        }

        public void LineDownExtend()
        {
            throw new NotImplementedException();
        }

        public void LineDownRectExtend()
        {
            throw new NotImplementedException();
        }

        public void LineDuplicate()
        {
            throw new NotImplementedException();
        }

        public void LineEnd()
        {
            throw new NotImplementedException();
        }

        public void LineEndDisplay()
        {
            throw new NotImplementedException();
        }

        public void LineEndDisplayExtend()
        {
            throw new NotImplementedException();
        }

        public void LineEndExtend()
        {
            throw new NotImplementedException();
        }

        public void LineEndRectExtend()
        {
            throw new NotImplementedException();
        }

        public void LineEndWrap()
        {
            throw new NotImplementedException();
        }

        public void LineEndWrapExtend()
        {
            throw new NotImplementedException();
        }

        public int LineFromPosition(Position pos)
        {
            throw new NotImplementedException();
        }

        public int LineLength(int line)
        {
            throw new NotImplementedException();
        }

        public void LineScroll(int columns, int lines)
        {
            throw new NotImplementedException();
        }

        public void LineScrollDown()
        {
            throw new NotImplementedException();
        }

        public void LineScrollUp()
        {
            throw new NotImplementedException();
        }

        public void LinesJoin()
        {
            throw new NotImplementedException();
        }

        public int LinesOnScreen()
        {
            throw new NotImplementedException();
        }

        public void LinesSplit(int pixelWidth)
        {
            throw new NotImplementedException();
        }

        public void LineTranspose()
        {
            throw new NotImplementedException();
        }

        public void LineUp()
        {
            throw new NotImplementedException();
        }

        public void LineUpExtend()
        {
            throw new NotImplementedException();
        }

        public void LineUpRectExtend()
        {
            throw new NotImplementedException();
        }

        public void LoadLexerLibrary(string path)
        {
            throw new NotImplementedException();
        }

        public void LowerCase()
        {
            throw new NotImplementedException();
        }

        public int MarginGetStyle(int line)
        {
            throw new NotImplementedException();
        }

        public int MarginGetStyleOffset()
        {
            throw new NotImplementedException();
        }

        public string MarginGetStyles(int line)
        {
            throw new NotImplementedException();
        }

        public string MarginGetText(int line)
        {
            throw new NotImplementedException();
        }

        public void MarginSetStyle(int line, int style)
        {
            throw new NotImplementedException();
        }

        public void MarginSetStyleOffset(int style)
        {
            throw new NotImplementedException();
        }

        public void MarginSetStyles(int line, string styles)
        {
            throw new NotImplementedException();
        }

        public void MarginSetText(int line, string text)
        {
            throw new NotImplementedException();
        }

        public void MarginTextClearAll()
        {
            throw new NotImplementedException();
        }

        public int MarkerAdd(int line, int markerNumber)
        {
            throw new NotImplementedException();
        }

        public void MarkerAddSet(int line, int set)
        {
            throw new NotImplementedException();
        }

        public void MarkerDefine(int markerNumber, int markerSymbol)
        {
            throw new NotImplementedException();
        }

        public void MarkerDefinePixmap(int markerNumber, string pixmap)
        {
            throw new NotImplementedException();
        }

        public void MarkerDefineRGBAImage(int markerNumber, string pixels)
        {
            throw new NotImplementedException();
        }

        public void MarkerDelete(int line, int markerNumber)
        {
            throw new NotImplementedException();
        }

        public void MarkerDeleteAll(int markerNumber)
        {
            throw new NotImplementedException();
        }

        public void MarkerDeleteHandle(int handle)
        {
            throw new NotImplementedException();
        }

        public void MarkerEnableHighlight(bool enabled)
        {
            throw new NotImplementedException();
        }

        public int MarkerGet(int line)
        {
            throw new NotImplementedException();
        }

        public int MarkerLineFromHandle(int handle)
        {
            throw new NotImplementedException();
        }

        public int MarkerNext(int lineStart, int markerMask)
        {
            throw new NotImplementedException();
        }

        public int MarkerPrevious(int lineStart, int markerMask)
        {
            throw new NotImplementedException();
        }

        public void MarkerSetAlpha(int markerNumber, int alpha)
        {
            throw new NotImplementedException();
        }

        public void MarkerSetBack(int markerNumber, Colour back)
        {
            throw new NotImplementedException();
        }

        public void MarkerSetBackSelected(int markerNumber, Colour back)
        {
            throw new NotImplementedException();
        }

        public void MarkerSetFore(int markerNumber, Colour fore)
        {
            throw new NotImplementedException();
        }

        public int MarkerSymbolDefined(int markerNumber)
        {
            throw new NotImplementedException();
        }

        public void MoveCaretInsideView()
        {
            throw new NotImplementedException();
        }

        public void MoveSelectedLinesDown()
        {
            throw new NotImplementedException();
        }

        public void MoveSelectedLinesUp()
        {
            throw new NotImplementedException();
        }

        public void NewLine()
        {
            //TODO:
        }

        public void Null()
        {
            throw new NotImplementedException();
        }

        public void PageDown()
        {
            throw new NotImplementedException();
        }

        public void PageDownExtend()
        {
            throw new NotImplementedException();
        }

        public void PageDownRectExtend()
        {
            throw new NotImplementedException();
        }

        public void PageUp()
        {
            throw new NotImplementedException();
        }

        public void PageUpExtend()
        {
            throw new NotImplementedException();
        }

        public void PageUpRectExtend()
        {
            throw new NotImplementedException();
        }

        public void ParaDown()
        {
            throw new NotImplementedException();
        }

        public void ParaDownExtend()
        {
            throw new NotImplementedException();
        }

        public void ParaUp()
        {
            throw new NotImplementedException();
        }

        public void ParaUpExtend()
        {
            throw new NotImplementedException();
        }

        public void Paste()
        {
            throw new NotImplementedException();
        }

        public int PointXFromPosition(Position pos)
        {
            throw new NotImplementedException();
        }

        public int PointYFromPosition(Position pos)
        {
            throw new NotImplementedException();
        }

        public Position PositionAfter(Position pos)
        {
            throw new NotImplementedException();
        }

        public Position PositionBefore(Position pos)
        {
            throw new NotImplementedException();
        }

        public Position PositionFromLine(int line)
        {
            throw new NotImplementedException();
        }

        public Position PositionFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Position PositionFromPointClose(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Position PositionRelative(Position pos, int relative)
        {
            throw new NotImplementedException();
        }

        public int PrivateLexerCall(int operation, int pointer)
        {
            throw new NotImplementedException();
        }

        public string PropertyNames()
        {
            throw new NotImplementedException();
        }

        public int PropertyType(string name)
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void RegisterImage(int type, string xpmData)
        {
            throw new NotImplementedException();
        }

        public void RegisterRGBAImage(int type, string pixels)
        {
            throw new NotImplementedException();
        }

        public void ReleaseAllExtendedStyles()
        {
            throw new NotImplementedException();
        }

        public void ReleaseDocument(int doc)
        {
            throw new NotImplementedException();
        }

        public void ReplaceSel(string text)
        {
            throw new NotImplementedException();
        }

        public int ReplaceTarget(int length, string text)
        {
            throw new NotImplementedException();
        }

        public int ReplaceTargetRE(int length, string text)
        {
            throw new NotImplementedException();
        }

        public void RGBAImageSetHeight(int height)
        {
            throw new NotImplementedException();
        }

        public void RGBAImageSetScale(int scalePercent)
        {
            throw new NotImplementedException();
        }

        public void RGBAImageSetWidth(int width)
        {
            throw new NotImplementedException();
        }

        public void RotateSelection()
        {
            throw new NotImplementedException();
        }

        public void ScrollCaret()
        {
            throw new NotImplementedException();
        }

        public void ScrollRange(Position secondary, Position primary)
        {
            throw new NotImplementedException();
        }

        public void ScrollToEnd()
        {
            throw new NotImplementedException();
        }

        public void ScrollToStart()
        {
            throw new NotImplementedException();
        }

        public void SearchAnchor()
        {
            throw new NotImplementedException();
        }

        public int SearchInTarget(int length, string text)
        {
            throw new NotImplementedException();
        }

        public int SearchNext(int flags, string text)
        {
            throw new NotImplementedException();
        }

        public int SearchPrev(int flags, string text)
        {
            throw new NotImplementedException();
        }

        public void SelectAll()
        {
            throw new NotImplementedException();
        }

        public void SelectCurrentLine()
        {
            throw new NotImplementedException();
        }

        public void SelectionDuplicate()
        {
            throw new NotImplementedException();
        }

        public bool SelectionIsRectangle()
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalCaretFore(Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalCaretsBlink(bool additionalCaretsBlink)
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalCaretsVisible(bool additionalCaretsBlink)
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalSelAlpha(int alpha)
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalSelBack(Colour back)
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalSelectionTyping(bool additionalSelectionTyping)
        {
            throw new NotImplementedException();
        }

        public void SetAdditionalSelFore(Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetAnchor(Position posAnchor)
        {
            throw new NotImplementedException();
        }

        public void SetAutomaticFold(int automaticFold)
        {
            throw new NotImplementedException();
        }

        public void SetBackSpaceUnIndents(bool bsUnIndents)
        {
            throw new NotImplementedException();
        }

        public void SetBufferedDraw(bool buffered)
        {
            throw new NotImplementedException();
        }

        public void SetCaretFore(Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetCaretLineBack(Colour back)
        {
            throw new NotImplementedException();
        }

        public void SetCaretLineBackAlpha(int alpha)
        {
            throw new NotImplementedException();
        }

        public void SetCaretLineVisible(bool show)
        {
            throw new NotImplementedException();
        }

        public void SetCaretLineVisibleAlways(bool alwaysVisible)
        {
            throw new NotImplementedException();
        }

        public void SetCaretPeriod(int periodMilliseconds)
        {
            throw new NotImplementedException();
        }

        public void SetCaretSticky(int useCaretStickyBehaviour)
        {
            throw new NotImplementedException();
        }

        public void SetCaretStyle(int caretStyle)
        {
            throw new NotImplementedException();
        }

        public void SetCaretWidth(int pixelWidth)
        {
            throw new NotImplementedException();
        }

        public void SetCharsDefault()
        {
            throw new NotImplementedException();
        }

        public void SetCodePage(int codePage)
        {
            throw new NotImplementedException();
        }

        public void SetControlCharSymbol(int symbol)
        {
            throw new NotImplementedException();
        }

        public void SetCurrentPos(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(int cursorType)
        {
            throw new NotImplementedException();
        }

        public void SetDocPointer(IntPtr pointer)
        {
            throw new NotImplementedException();
        }

        public void SetEdgeColour(Colour edgeColour)
        {
            throw new NotImplementedException();
        }

        public void SetEdgeColumn(int column)
        {
            throw new NotImplementedException();
        }

        public void SetEdgeMode(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetEmptySelection(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetEndAtLastLine(bool endAtLastLine)
        {
            throw new NotImplementedException();
        }

        public void SetEOLMode(int eolMode)
        {
            throw new NotImplementedException();
        }

        public void SetExtraAscent(int extraAscent)
        {
            throw new NotImplementedException();
        }

        public void SetExtraDescent(int extraDescent)
        {
            throw new NotImplementedException();
        }

        public void SetFirstVisibleLine(int lineDisplay)
        {
            throw new NotImplementedException();
        }

        public void SetFocus(bool focus)
        {
            throw new NotImplementedException();
        }

        public void SetFoldExpanded(int line, bool expanded)
        {
            throw new NotImplementedException();
        }

        public void SetFoldFlags(int flags)
        {
            throw new NotImplementedException();
        }

        public void SetFoldLevel(int line, int level)
        {
            throw new NotImplementedException();
        }

        public void SetFoldMarginColour(bool useSetting, Colour back)
        {
            throw new NotImplementedException();
        }

        public void SetFoldMarginHiColour(bool useSetting, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetFontQuality(int fontQuality)
        {
            throw new NotImplementedException();
        }

        public void SetHighlightGuide(int column)
        {
            throw new NotImplementedException();
        }

        public void SetHotspotActiveBack(bool useSetting, Colour back)
        {
            throw new NotImplementedException();
        }

        public void SetHotspotActiveFore(bool useSetting, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetHotspotActiveUnderline(bool underline)
        {
            throw new NotImplementedException();
        }

        public void SetHotspotSingleLine(bool singleLine)
        {
            throw new NotImplementedException();
        }

        public void SetHScrollBar(bool show)
        {
            throw new NotImplementedException();
        }

        public void SetIdentifier(int identifier)
        {
            throw new NotImplementedException();
        }

        public void SetIdentifiers(int style, string identifiers)
        {
            throw new NotImplementedException();
        }

        public void SetIMEInteraction(int imeInteraction)
        {
            throw new NotImplementedException();
        }

        public void SetIndent(int indentSize)
        {
            throw new NotImplementedException();
        }

        public void SetIndentationGuides(int indentView)
        {
            throw new NotImplementedException();
        }

        public void SetIndicatorCurrent(int indicator)
        {
            throw new NotImplementedException();
        }

        public void SetIndicatorValue(int value)
        {
            throw new NotImplementedException();
        }

        public void SetKeysUnicode(bool keysUnicode)
        {
            throw new NotImplementedException();
        }

        public void SetKeyWords(int keywordSet, string keyWords)
        {
            throw new NotImplementedException();
        }

        public void SetLayoutCache(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetLengthForEncode(int bytes)
        {
            throw new NotImplementedException();
        }

        public void SetLexer(int lexer)
        {
            throw new NotImplementedException();
        }

        public void SetLexerLanguage(string language)
        {
            throw new NotImplementedException();
        }

        public void SetLineEndTypesAllowed(int lineEndBitSet)
        {
            throw new NotImplementedException();
        }

        public void SetLineIndentation(int line, int indentSize)
        {
            throw new NotImplementedException();
        }

        public void SetLineState(int line, int state)
        {
            throw new NotImplementedException();
        }

        public void SetMainSelection(int selection)
        {
            throw new NotImplementedException();
        }

        public void SetMarginCursorN(int margin, int cursor)
        {
            throw new NotImplementedException();
        }

        public void SetMarginLeft(int pixelWidth)
        {
            throw new NotImplementedException();
        }

        public void SetMarginMaskN(int margin, int mask)
        {
            throw new NotImplementedException();
        }

        public void SetMarginOptions(int marginOptions)
        {
            throw new NotImplementedException();
        }

        public void SetMarginRight(int pixelWidth)
        {
            throw new NotImplementedException();
        }

        public void SetMarginSensitiveN(int margin, bool sensitive)
        {
            throw new NotImplementedException();
        }

        public void SetMarginTypeN(int margin, int marginType)
        {
            throw new NotImplementedException();
        }

        public void SetMarginWidthN(int margin, int pixelWidth)
        {
            throw new NotImplementedException();
        }

        public void SetModEventMask(int mask)
        {
            throw new NotImplementedException();
        }

        public void SetMouseDownCaptures(bool captures)
        {
            throw new NotImplementedException();
        }

        public void SetMouseDwellTime(int periodMilliseconds)
        {
            throw new NotImplementedException();
        }

        public void SetMouseSelectionRectangularSwitch(bool mouseSelectionRectangularSwitch)
        {
            throw new NotImplementedException();
        }

        public void SetMultiPaste(int multiPaste)
        {
            throw new NotImplementedException();
        }

        public void SetMultipleSelection(bool multipleSelection)
        {
            throw new NotImplementedException();
        }

        public void SetOvertype(bool overtype)
        {
            throw new NotImplementedException();
        }

        public void SetPasteConvertEndings(bool convert)
        {
            throw new NotImplementedException();
        }

        public void SetPhasesDraw(int phases)
        {
            throw new NotImplementedException();
        }

        public void SetPositionCache(int size)
        {
            throw new NotImplementedException();
        }

        public void SetPrintColourMode(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetPrintMagnification(int magnification)
        {
            throw new NotImplementedException();
        }

        public void SetPrintWrapMode(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string key, string value)
        {
            throw new NotImplementedException();
        }

        public void SetPunctuationChars(string characters)
        {
            throw new NotImplementedException();
        }

        public void SetReadOnly(bool readOnly)
        {
            throw new NotImplementedException();
        }

        public void SetRectangularSelectionAnchor(Position posAnchor)
        {
            throw new NotImplementedException();
        }

        public void SetRectangularSelectionAnchorVirtualSpace(int space)
        {
            throw new NotImplementedException();
        }

        public void SetRectangularSelectionCaret(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetRectangularSelectionCaretVirtualSpace(int space)
        {
            throw new NotImplementedException();
        }

        public void SetRectangularSelectionModifier(int modifier)
        {
            throw new NotImplementedException();
        }

        public void SetRepresentation(string encodedCharacter, string representation)
        {
            throw new NotImplementedException();
        }

        public void SetSavePoint()
        {
            throw new NotImplementedException();
        }

        public void SetScrollWidth(int pixelWidth)
        {
            throw new NotImplementedException();
        }

        public void SetScrollWidthTracking(bool tracking)
        {
            throw new NotImplementedException();
        }

        public void SetSearchFlags(int flags)
        {
            throw new NotImplementedException();
        }

        public void SetSel(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public void SetSelAlpha(int alpha)
        {
            throw new NotImplementedException();
        }

        public void SetSelBack(bool useSetting, Colour back)
        {
            throw new NotImplementedException();
        }

        public int SetSelection(int caret, int anchor)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionEnd(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionMode(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionNAnchor(int selection, Position posAnchor)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionNAnchorVirtualSpace(int selection, int space)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionNCaret(int selection, Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionNCaretVirtualSpace(int selection, int space)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionNEnd(int selection, Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionNStart(int selection, Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionStart(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetSelEOLFilled(bool filled)
        {
            throw new NotImplementedException();
        }

        public void SetSelFore(bool useSetting, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetStatus(int statusCode)
        {
            throw new NotImplementedException();
        }

        public void SetStyleBits(int bits)
        {
            throw new NotImplementedException();
        }

        public void SetStyling(int length, int style)
        {
            throw new NotImplementedException();
        }

        public void SetStylingEx(int length, string styles)
        {
            throw new NotImplementedException();
        }

        public void SetTabIndents(bool tabIndents)
        {
            throw new NotImplementedException();
        }

        public void SetTabWidth(int tabWidth)
        {
            throw new NotImplementedException();
        }

        public void SetTargetEnd(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetTargetRange(Position start, Position end)
        {
            throw new NotImplementedException();
        }

        public void SetTargetStart(Position pos)
        {
            throw new NotImplementedException();
        }

        public void SetTechnology(int technology)
        {
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public void SetTwoPhaseDraw(bool twoPhase)
        {
            throw new NotImplementedException();
        }

        public void SetUndoCollection(bool collectUndo)
        {
            throw new NotImplementedException();
        }

        public void SetUsePalette(bool usePalette)
        {
            throw new NotImplementedException();
        }

        public void SetUseTabs(bool useTabs)
        {
            throw new NotImplementedException();
        }

        public void SetViewEOL(bool visible)
        {
            throw new NotImplementedException();
        }

        public void SetViewWS(int viewWS)
        {
            throw new NotImplementedException();
        }

        public void SetVirtualSpaceOptions(int virtualSpaceOptions)
        {
            throw new NotImplementedException();
        }

        public void SetVisiblePolicy(int visiblePolicy, int visibleSlop)
        {
            throw new NotImplementedException();
        }

        public void SetVScrollBar(bool show)
        {
            throw new NotImplementedException();
        }

        public void SetWhitespaceBack(bool useSetting, Colour back)
        {
            throw new NotImplementedException();
        }

        public void SetWhitespaceChars(string characters)
        {
            throw new NotImplementedException();
        }

        public void SetWhitespaceFore(bool useSetting, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void SetWhitespaceSize(int size)
        {
            throw new NotImplementedException();
        }

        public void SetWordChars(string characters)
        {
            throw new NotImplementedException();
        }

        public void SetWrapIndentMode(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetWrapMode(int mode)
        {
            throw new NotImplementedException();
        }

        public void SetWrapStartIndent(int indent)
        {
            throw new NotImplementedException();
        }

        public void SetWrapVisualFlags(int wrapVisualFlags)
        {
            throw new NotImplementedException();
        }

        public void SetWrapVisualFlagsLocation(int wrapVisualFlagsLocation)
        {
            throw new NotImplementedException();
        }

        public void SetXCaretPolicy(int caretPolicy, int caretSlop)
        {
            throw new NotImplementedException();
        }

        public void SetXOffset(int newOffset)
        {
            throw new NotImplementedException();
        }

        public void SetYCaretPolicy(int caretPolicy, int caretSlop)
        {
            throw new NotImplementedException();
        }

        public void SetZoom(int zoom)
        {
            throw new NotImplementedException();
        }

        public void ShowLines(int lineStart, int lineEnd)
        {
            throw new NotImplementedException();
        }

        public void StartRecord()
        {
            throw new NotImplementedException();
        }

        public void StartStyling(Position pos, int mask)
        {
            throw new NotImplementedException();
        }

        public void StopRecord()
        {
            throw new NotImplementedException();
        }

        public void StutteredPageDown()
        {
            throw new NotImplementedException();
        }

        public void StutteredPageDownExtend()
        {
            throw new NotImplementedException();
        }

        public void StutteredPageUp()
        {
            throw new NotImplementedException();
        }

        public void StutteredPageUpExtend()
        {
            throw new NotImplementedException();
        }

        public void StyleClearAll()
        {
            throw new NotImplementedException();
        }

        public Colour StyleGetBack(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetBold(int style)
        {
            throw new NotImplementedException();
        }

        public int StyleGetCase(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetChangeable(int style)
        {
            throw new NotImplementedException();
        }

        public int StyleGetCharacterSet(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetEOLFilled(int style)
        {
            throw new NotImplementedException();
        }

        public string StyleGetFont(int style)
        {
            throw new NotImplementedException();
        }

        public Colour StyleGetFore(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetHotSpot(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetItalic(int style)
        {
            throw new NotImplementedException();
        }

        public int StyleGetSize(int style)
        {
            throw new NotImplementedException();
        }

        public int StyleGetSizeFractional(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetUnderline(int style)
        {
            throw new NotImplementedException();
        }

        public bool StyleGetVisible(int style)
        {
            throw new NotImplementedException();
        }

        public int StyleGetWeight(int style)
        {
            throw new NotImplementedException();
        }

        public void StyleResetDefault()
        {
            throw new NotImplementedException();
        }

        public void StyleSetBack(int style, Colour back)
        {
            throw new NotImplementedException();
        }

        public void StyleSetBold(int style, bool bold)
        {
            throw new NotImplementedException();
        }

        public void StyleSetCase(int style, int caseForce)
        {
            throw new NotImplementedException();
        }

        public void StyleSetChangeable(int style, bool changeable)
        {
            throw new NotImplementedException();
        }

        public void StyleSetCharacterSet(int style, int characterSet)
        {
            throw new NotImplementedException();
        }

        public void StyleSetEOLFilled(int style, bool filled)
        {
            throw new NotImplementedException();
        }

        public void StyleSetFont(int style, string fontName)
        {
            throw new NotImplementedException();
        }

        public void StyleSetFore(int style, Colour fore)
        {
            throw new NotImplementedException();
        }

        public void StyleSetHotSpot(int style, bool hotspot)
        {
            throw new NotImplementedException();
        }

        public void StyleSetItalic(int style, bool italic)
        {
            throw new NotImplementedException();
        }

        public void StyleSetSize(int style, int sizePoints)
        {
            throw new NotImplementedException();
        }

        public void StyleSetSizeFractional(int style, int caseForce)
        {
            throw new NotImplementedException();
        }

        public void StyleSetUnderline(int style, bool underline)
        {
            throw new NotImplementedException();
        }

        public void StyleSetVisible(int style, bool visible)
        {
            throw new NotImplementedException();
        }

        public void StyleSetWeight(int style, int weight)
        {
            throw new NotImplementedException();
        }

        public void SwapMainAnchorCaret()
        {
            throw new NotImplementedException();
        }

        public void Tab()
        {
            throw new NotImplementedException();
        }

        public string TargetAsUTF8()
        {
            throw new NotImplementedException();
        }

        public void TargetFromSelection()
        {
            throw new NotImplementedException();
        }

        public int TextHeight(int line)
        {
            throw new NotImplementedException();
        }

        public int TextWidth(int style, string text)
        {
            throw new NotImplementedException();
        }

        public void ToggleCaretSticky()
        {
            throw new NotImplementedException();
        }

        public void ToggleFold(int line)
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void UpperCase()
        {
            throw new NotImplementedException();
        }

        public void UsePopUp(bool allowPopUp)
        {
            throw new NotImplementedException();
        }

        public void UserListShow(int listType, string itemList)
        {
            throw new NotImplementedException();
        }

        public void VCHome()
        {
            throw new NotImplementedException();
        }

        public void VCHomeDisplay()
        {
            throw new NotImplementedException();
        }

        public void VCHomeDisplayExtend()
        {
            throw new NotImplementedException();
        }

        public void VCHomeExtend()
        {
            throw new NotImplementedException();
        }

        public void VCHomeRectExtend()
        {
            throw new NotImplementedException();
        }

        public void VCHomeWrap()
        {
            throw new NotImplementedException();
        }

        public void VCHomeWrapExtend()
        {
            throw new NotImplementedException();
        }

        public void VerticalCentreCaret()
        {
            throw new NotImplementedException();
        }

        public int VisibleFromDocLine(int line)
        {
            throw new NotImplementedException();
        }

        public int WordEndPosition(Position pos, bool onlyWordCharacters)
        {
            throw new NotImplementedException();
        }

        public void WordLeft()
        {
            throw new NotImplementedException();
        }

        public void WordLeftEnd()
        {
            throw new NotImplementedException();
        }

        public void WordLeftEndExtend()
        {
            throw new NotImplementedException();
        }

        public void WordLeftExtend()
        {
            throw new NotImplementedException();
        }

        public void WordPartLeft()
        {
            throw new NotImplementedException();
        }

        public void WordPartLeftExtend()
        {
            throw new NotImplementedException();
        }

        public void WordPartRight()
        {
            throw new NotImplementedException();
        }

        public void WordPartRightExtend()
        {
            throw new NotImplementedException();
        }

        public void WordRight()
        {
            throw new NotImplementedException();
        }

        public void WordRightEnd()
        {
            throw new NotImplementedException();
        }

        public void WordRightEndExtend()
        {
            throw new NotImplementedException();
        }

        public void WordRightExtend()
        {
            throw new NotImplementedException();
        }

        public int WordStartPosition(Position pos, bool onlyWordCharacters)
        {
            throw new NotImplementedException();
        }

        public int WrapCount(int line)
        {
            throw new NotImplementedException();
        }

        public void ZoomIn()
        {
            throw new NotImplementedException();
        }

        public void ZoomOut()
        {
            throw new NotImplementedException();
        }
    }
}
