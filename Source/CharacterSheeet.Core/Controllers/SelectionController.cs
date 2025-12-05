using Meadow;
using Meadow.Foundation.Graphics.MicroLayout;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheeet.Core;

/// <summary>
/// Manages selection state and navigation for selectable controls.
/// </summary>
public class SelectionController
{
    private readonly List<ISelectable> _selectables = new();
    private int _currentIndex = -1;

    /// <summary>
    /// Event raised when the selection changes.
    /// </summary>
    public event EventHandler<ISelectable?>? SelectionChanged;

    /// <summary>
    /// Gets the currently selected control, or null if nothing is selected.
    /// </summary>
    public ISelectable? CurrentSelection =>
        _currentIndex >= 0 && _currentIndex < _selectables.Count
            ? _selectables[_currentIndex]
            : null;

    /// <summary>
    /// Gets whether any control is currently selected.
    /// </summary>
    public bool HasSelection => CurrentSelection != null;

    /// <summary>
    /// Gets whether the current selection is activated for editing.
    /// </summary>
    public bool IsActivated => CurrentSelection?.IsActivated ?? false;

    /// <summary>
    /// Registers a selectable control with the controller.
    /// Controls are automatically sorted by SelectionIndex.
    /// </summary>
    /// <param name="selectable">The selectable control to register.</param>
    public void Register(ISelectable selectable)
    {
        if (!_selectables.Contains(selectable))
        {
            _selectables.Add(selectable);
            _selectables.Sort((a, b) => a.SelectionIndex.CompareTo(b.SelectionIndex));
        }
    }

    /// <summary>
    /// Registers multiple selectable controls.
    /// </summary>
    /// <param name="selectables">The controls to register.</param>
    public void RegisterRange(IEnumerable<ISelectable> selectables)
    {
        foreach (var selectable in selectables)
        {
            Register(selectable);
        }
    }

    /// <summary>
    /// Clears all registered selectables and resets selection.
    /// </summary>
    public void Clear()
    {
        ClearSelection();
        _selectables.Clear();
    }

    /// <summary>
    /// Clears the current selection without removing registered controls.
    /// </summary>
    public void ClearSelection()
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.IsSelected = false;
            _currentIndex = -1;
            SelectionChanged?.Invoke(this, null);
        }
    }

    /// <summary>
    /// Selects the next control in the selection order.
    /// Wraps around to the first control if at the end.
    /// </summary>
    public void SelectNext()
    {
        if (_selectables.Count == 0) return;

        // Deselect and deactivate current
        if (CurrentSelection != null)
        {
            CurrentSelection.IsSelected = false;
            CurrentSelection.IsActivated = false;
        }

        // Move to next
        _currentIndex = (_currentIndex + 1) % _selectables.Count;

        // Select new
        if (CurrentSelection != null)
        {
            CurrentSelection.IsSelected = true;
            SelectionChanged?.Invoke(this, CurrentSelection);
        }
    }

    /// <summary>
    /// Selects the previous control in the selection order.
    /// Wraps around to the last control if at the beginning.
    /// </summary>
    public void SelectPrevious()
    {
        if (_selectables.Count == 0) return;

        // Deselect and deactivate current
        if (CurrentSelection != null)
        {
            CurrentSelection.IsSelected = false;
            CurrentSelection.IsActivated = false;
        }

        // Move to previous
        _currentIndex--;
        if (_currentIndex < 0)
        {
            _currentIndex = _selectables.Count - 1;
        }

        // Select new
        if (CurrentSelection != null)
        {
            CurrentSelection.IsSelected = true;
            SelectionChanged?.Invoke(this, CurrentSelection);
        }
    }

    /// <summary>
    /// Selects the first control in the selection order.
    /// </summary>
    public void SelectFirst()
    {
        if (_selectables.Count == 0) return;

        ClearSelection();
        _currentIndex = 0;

        if (CurrentSelection != null)
        {
            CurrentSelection.IsSelected = true;
            SelectionChanged?.Invoke(this, CurrentSelection);
        }
    }

    /// <summary>
    /// Selects a specific control by its SelectionIndex.
    /// </summary>
    /// <param name="selectionIndex">The selection index to select.</param>
    /// <returns>True if a control with that index was found and selected.</returns>
    public bool SelectByIndex(int selectionIndex)
    {
        var control = _selectables.FirstOrDefault(s => s.SelectionIndex == selectionIndex);
        if (control == null) return false;

        ClearSelection();
        _currentIndex = _selectables.IndexOf(control);
        control.IsSelected = true;
        SelectionChanged?.Invoke(this, control);
        return true;
    }

    /// <summary>
    /// Toggles the activation state of the currently selected control.
    /// When activated, the control is ready for value editing.
    /// </summary>
    public void ToggleActivation()
    {
        if (CurrentSelection == null) return;

        CurrentSelection.IsActivated = !CurrentSelection.IsActivated;
        Resolver.Log.Info($"Control {(CurrentSelection.IsActivated ? "activated" : "deactivated")}");
    }

    /// <summary>
    /// Deactivates the currently selected control.
    /// </summary>
    public void Deactivate()
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.IsActivated = false;
        }
    }
}
