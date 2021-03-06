﻿/* An enumeration for controlling how a change in tilemap size is
 * affected throughout the program flow. For example, if we change the
 * tilemap's view size, then we need to change the control's client size,
 * and then its parent form's size.
 *
 * But if we instead change the parent form's size first, then we need
 * to change the view size, and then client size last. Also, we need to
 * modify the form size according by discrete amounts to bind to the
 *
 *
 *
 */

namespace MushROMs.Controls
{
    public enum TileMapResizeMode
    {
        None,
        TileMapCellResize,
        ControlResize,
        FormResize
    }
}
