using System.Collections;
public class Robot
{
    public List<Point> getPath1(bool[][] maze) {
		if (maze == null || maze.Length == 0) {
			return null;
		}
		List<Point> res = new List<Point>();
		if (getPath1(maze, maze.Length - 1, maze[0].Length - 1, res)) {
			return res;
		}
		return null;
	}

	private bool getPath1(bool[][] maze, int row, int col, List<Point> path) {
		// out of bounds or not available
		if (!maze[row][col] || col < 0 || row < 0) {
			return false;
		}
		bool isAtOrigin = (row == 0) && (col == 0);
		if (getPath1(maze, row, col - 1, path) || getPath1(maze, row - 1, col, path) || isAtOrigin) {
			Point p = new Point(row, col);
			path.Add(p);
			return true;
		}
		return false;
    }
}