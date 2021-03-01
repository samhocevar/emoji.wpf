/*********************************************************************************************\

 Boolean-Operations-Plugin for JavaScript Vector Library Raphaël 2.1 (http://raphaeljs.com/)
 Copyright © 2013 Thomas Richter (https://github.com/poilu/raphael-boolean)
 Licensed under the MIT license (http://opensource.org/licenses/MIT)

\*********************************************************************************************/

/*********************************************************************************************\

 Version: 0.2 (released 2013-07-01)
 
 	Contributions:
 	Bruno Heridet (https://github.com/Delapouite)

	TODO:
	Currently the plugin is not able to handle self intersecting (sub-)paths properly.
	This is concerning fills in SVG due to default non-zero fill rule.
	Such sub-paths should be splitted into closed and not self intersecting sub-paths
	while removing not filled ones before performing the boolean operation.

\*********************************************************************************************/

(function() {
	/**
	 * convert a path array into path string
	 *
	 * @param arr pathArr
	 *
	 * @returns string
	 */
	var pathArrToStr = function(pathArr) {
		return pathArr.join(",").replace(/,?([achlmqrstvxz]),?/gi, "$1");
	};

	/**
	 * Shortcut helper
	 *
	 * @returns string (path string)
	 */
	var pathSegsToStr = function(pathSegs) {
		return pathArrToStr(pathSegsToArr(pathSegs));
	};

	/**
	 * convert raphael's internal path representation (must be converted to curves before) to segments / bezier curves
	 *
	 * @param array pathArr (RaphaelJS path array)
	 *
	 * @returns array pathSegs (path as a collection of segments)
	 */
	var pathArrToSegs = function(pathArr) {
		var pathSegs = [];

		for (var i = 0; i < pathArr.length; i++) {
			//if command is a moveto create new sub-path
			var seg = [];
			if (pathArr[i][0] != "M") {

				seg.push(pathArr[i - 1][pathArr[i - 1].length - 2], pathArr[i - 1][pathArr[i - 1].length - 1]);

				for (var j = 1; j < pathArr[i].length; j++) {
					seg.push(pathArr[i][j]);
				}
			}
			//add empty segments for "moveto", because Raphael counts it when calculating interceptions
			if (i > 0) {
				pathSegs.push(seg);
			}

		}

		return pathSegs;
	};

	/**
	 * convert segments / bezier curves representation of a path to raphael's internal path representation (svg commands as array)
	 *
	 * @param array pathSegs (path as a collection of segments)
	 *
	 * @returns array pathArr (RaphaelJS path array)
	 */
	var pathSegsToArr = function(pathSegs) {
		var pathArr = [];

		for (var i = 0; i < pathSegs.length; i++) {
			//ignore empty segments
			if (pathSegs[i].length === 0) {
				continue;
			}
			var command = [];
			//if start point of current segment is different from end point of previous segment add a new subpath
			if (i === 0 || (pathSegs[i][0] != pathSegs[i - 1][pathSegs[i - 1].length - 2] || pathSegs[i][1] != pathSegs[i - 1][pathSegs[i - 1].length - 1])) {
				command.push("M", pathSegs[i][0], pathSegs[i][1]);
				pathArr.push(command);
				command = [];
			}
			command.push("C");

			for (var j = 2; j < pathSegs[i].length; j++) {
				command.push(pathSegs[i][j]);
			}
			pathArr.push(command);
		}

		return pathArr;
	};

	/**
	 * convert a non-path RaphaelJS-Object (rect, circle, ellipse) into a path
	 *
	 * @param object obj
	 *
	 * @returns string (path string)
	 */
	var toPath = function(el) {
		var path = [],
			a = el.attrs;

		switch (el.type) {
			case "rect":
				var rx = a.r,
					ry = a.r,
					cornerPoints = [
						[a.x, a.y],
						[a.x + a.width, a.y],
						[a.x + a.width, a.y + a.height],
						[a.x, a.y + a.height]
					];
				break;
			case "circle":
				var rx = a.r,
					ry = a.r,
					cornerPoints = [
						[a.cx - rx, a.cy - ry],
						[a.cx + rx, a.cy - ry],
						[a.cx + rx, a.cy + ry],
						[a.cx - rx, a.cy + ry]
					];
				break;
			case "ellipse":
				var rx = a.rx,
					ry = a.ry,
					cornerPoints = [
						[a.cx - rx, a.cy - ry],
						[a.cx + rx, a.cy - ry],
						[a.cx + rx, a.cy + ry],
						[a.cx - rx, a.cy + ry]
					];
				break;
		}

		var radiusShift = [
			[
				[0, 1],
				[1, 0]
			],
			[
				[-1, 0],
				[0, 1]
			],
			[
				[0, -1],
				[-1, 0]
			],
			[
				[1, 0],
				[0, -1]
			]
		];
		//iterate all corners
		for (var i = 0; i <= 3; i++) {
			//insert starting point
			if (i === 0) {
				path.push(["M", cornerPoints[0][0], cornerPoints[0][1] + ry]);
			}

			//insert "curveto" (radius factor .446 is taken from Inkscape)
			if (rx > 0) {
				var c1 = [cornerPoints[i][0] + radiusShift[i][0][0] * rx * 0.446, cornerPoints[i][1] + radiusShift[i][0][1] * ry * 0.446];
				var c2 = [cornerPoints[i][0] + radiusShift[i][1][0] * rx * 0.446, cornerPoints[i][1] + radiusShift[i][1][1] * ry * 0.446];
				var p2 = [cornerPoints[i][0] + radiusShift[i][1][0] * rx, cornerPoints[i][1] + radiusShift[i][1][1] * ry];
				path.push(["C", c1[0], c1[1], c2[0], c2[1], p2[0], p2[1]]);
			}

			if (i < 3) {
				//if it's a rectangle draw line to next corner (point)
				if (el.type == "rect") {
					var p1 = [cornerPoints[i + 1][0] + radiusShift[i + 1][0][0] * rx, cornerPoints[i + 1][1] + radiusShift[i + 1][0][1] * ry];
					path.push(["L", p1[0], p1[1]]);
				}
			} else {
				path.push(["Z"]);
			}
		}

		return pathArrToStr(path);
	};

	/**
	 * mark the starting and ending points of all subpaths
	 * to simplify later building of closed paths
	 *
	 * @params (a list of paths in segment representation)
	 *
	 * @returns void
	 */
	var markSubpathEndings = function() {
		var subPaths = 0, //store overall number of existing subpaths (for id generation)
			path;

		//iterate paths
		for (var i = 0; i < arguments.length; i++) {
			path = arguments[i];
			//iterate path segments
			for (var j = 0; j < path.length; j++) {
				//first segment of a path has always starting point of subpath
				if (j === 0) {
					path[j].startPoint = "S" + subPaths;
				}

				//if ending point of a segment is different from starting  point of next seg. mark both
				if (j < path.length - 1) {
					if (path[j][6] != path[j + 1][0] || path[j][7] != path[j + 1][1]) {
						path[j].endPoint = "S" + subPaths;
						subPaths++;
						path[j + 1].startPoint = "S" + subPaths;
					}
				}

				//if all coords of a segment are the same mark starting and ending point (RaphaelJS bug)

				//last segment of a path has always ending point of subpath
				if (j == path.length - 1) {
					path[j].endPoint = "S" + subPaths;
					subPaths++;
				}
			}
		}
	};

	/**
	 * splits a segment of given path into two by using de Casteljau's algorithm (http://en.wikipedia.org/wiki/De_Casteljau%27s_algorithm - Geometric interpretation)
	 *
	 * @param array pathSegs (segment representation of a path returned by function pathArrToSegs)
	 * @param int segNr (nr of the segment - starting with 1, like it is returned by Raphael.pathIntersection: segment1, segment2)
	 *
	 * @returns void
	 */
	var splitSegment = function(pathSegs, segNr, t, newPoint, intersId) {
		var oldSeg = pathSegs[segNr - 1];

		//new anchor for start point of segment / bezier curve
		var newA1_1 = [oldSeg[0] + t * (oldSeg[2] - oldSeg[0]), oldSeg[1] + t * (oldSeg[3] - oldSeg[1])];
		//new anchor for end point of segment / bezier curve
		var newA2_2 = [oldSeg[4] + t * (oldSeg[6] - oldSeg[4]), oldSeg[5] + t * (oldSeg[7] - oldSeg[5])];

		//intermediate point between the two original anchors
		var iP = [oldSeg[2] + t * (oldSeg[4] - oldSeg[2]), oldSeg[3] + t * (oldSeg[5] - oldSeg[3])];

		//calculate anchors for the inserted point
		var newA1_2 = [newA1_1[0] + t * (iP[0] - newA1_1[0]), newA1_1[1] + t * (iP[1] - newA1_1[1])];
		var newA2_1 = [iP[0] + t * (newA2_2[0] - iP[0]), iP[1] + t * (newA2_2[1] - iP[1])];

		//set coordinates for new segments
		var newSeg1 = [oldSeg[0], oldSeg[1], newA1_1[0], newA1_1[1], newA1_2[0], newA1_2[1], newPoint[0], newPoint[1]];
		if (typeof oldSeg.startPoint != "undefined") {
			newSeg1.startPoint = oldSeg.startPoint;
		}
		newSeg1.endPoint = "I" + intersId; //mark end point as intersection

		var newSeg2 = [newPoint[0], newPoint[1], newA2_1[0], newA2_1[1], newA2_2[0], newA2_2[1], oldSeg[6], oldSeg[7]];
		newSeg2.startPoint = "I" + intersId; //mark start point as intersection
		if (typeof oldSeg.endPoint != "undefined") {
			newSeg2.endPoint = oldSeg.endPoint;
		}

		//insert new segments and replace the old one
		pathSegs.splice(segNr - 1, 1, newSeg1, newSeg2);
	};

	/**
	 * add points path given by intersections array
	 *
	 * @param array pathSegs (path in segement representation)
	 * @param array inters (intersections returned by Raphael.pathIntersection)
	 *
	 * @returns void
	 */
	var insertIntersectionPoints = function(pathSegs, pathNr, inters) {
		for (var i = 0; i < inters.length; i++) {
			var splits = 0;
			var t = inters[i]["t" + pathNr];
			var t1 = 0;
			var t2 = 1;

			for (var j = 0; j <= i; j++) {
				//check if previous segments where splitted before (influences segment nr)
				if (inters[j]["segment" + pathNr] < inters[i]["segment" + pathNr]) {
					splits++;
				}

				//check if currently affected segment was splitted before
				//this influences segment nr and t -> get nearest t1 (lower) and t2 (higher) for recalculation of t
				if (inters[j]["segment" + pathNr] == inters[i]["segment" + pathNr]) {
					if (inters[j]["t" + pathNr] < t) {
						splits++;
						if (inters[j]["t" + pathNr] > t1) {
							t1 = inters[j]["t" + pathNr];
						}
					}

					if (inters[j]["t" + pathNr] > t && inters[j]["t" + pathNr] < t2) {
						t2 = inters[j]["t" + pathNr];
					}
				}

			}

			//recalculate t
			t = (t - t1) / (t2 - t1);

			//split intersected segments
			splitSegment(pathSegs, inters[i]["segment" + pathNr] + splits, t, [inters[i].x, inters[i].y], i);

		}
	};

	/**
	 * checks wether a segment is inside a path by selecting the point at t = 0.5 (only works properly after inserting intersections)
	 *
	 * @param array seg (segment of a path)
	 * @param string path (string representation of the [other] path)
	 *
	 * @returns bool
	 */
	var isSegInsidePath = function(seg, path) {
		//get point on segment (t = 0.5)
		var point = Raphael.findDotsAtSegment(seg[0], seg[1], seg[2], seg[3], seg[4], seg[5], seg[6], seg[7], 0.5);

		//is point inside of given path
		return Raphael.isPointInsidePath(path, point.x, point.y);
	};

	/**
	 * find the two segments that touch the given intersection
	 *
	 * @param int intersId (id of the intersection returned by Raphael.pathIntersection)
	 * @param array pathSegArr (segment representation of a path)
	 *
	 * @returns array (contains ids of the segments)
	 */
	var findSegmentsByIntersId = function(intersId, pathSegArr) {
		for (var i = 0; i < pathSegArr.length; i++) {
			if (typeof pathSegArr[i].endPoint != "undefined" && pathSegArr[i].endPoint == intersId) {
				break;
			}
		}

		return [i, i + 1];
	};

	/**
	 * invert the coordinates of given segment array
	 *
	 * @param array segCoords (representing the coords of a segment, length = 7)
	 *
	 * @returns void
	 */
	var invertSeg = function(segCoords) {
		var tmp = JSON.parse(JSON.stringify(segCoords));
		segCoords[0] = tmp[6];
		segCoords[1] = tmp[7];
		segCoords[2] = tmp[4];
		segCoords[3] = tmp[5];
		segCoords[4] = tmp[2];
		segCoords[5] = tmp[3];
		segCoords[6] = tmp[0];
		segCoords[7] = tmp[1];

		//return [segCoords[6], segCoords[7], segCoords[4], segCoords[5], segCoords[2], segCoords[3], segCoords[0], segCoords[1]];
		//return segCoords;
	};

	/**
	 * invert the given part (of a path), including coordinates in segments, starting and ending points
	 *
	 * @param array part
	 *
	 * returns void
	 */
	var invertPart = function(part) {
		for (var q = 0; q < part.length; q++) {
			invertSeg(part[q]);
		}
		//invert order of segments
		part.reverse();

		//switch starting and ending points
		var oldStartPoint = part[part.length - 1].startPoint;
		part[0].startPoint = part[0].endPoint;
		if (part.length > 1) {
			delete part[0].endPoint;
		}

		part[part.length - 1].endPoint = oldStartPoint;
		if (part.length > 1) {
			delete part[part.length - 1].startPoint;
		}
	};

	/**
	 * calculate the direction of the given path
	 *
	 * @param array pathSegArr (path array in segment representation)
	 *
	 * @returns int dir (1: clockwise, -1: counter clockwise)
	 */
	var getPathDirection = function(pathSegArr) {
		var dir = -1;
		var minT, maxT;

		//get y of path's starting point
		var startY = pathSegArr[0][1];

		//convert path to string
		var path = pathSegsToStr(pathSegArr);
		var box = Raphael.pathBBox(path);

		//"draw" a horizontal line from left to right at half height of path's bbox
		var lineY = box.y + box.height / 2;
		var line = ("M" + box.x + "," + lineY + "L" + box.x2 + "," + lineY);

		//get intersections of line and path
		var inters = Raphael.pathIntersection(line, path);

		//get intersections with extrema for t on line
		for (var i = 0; i < inters.length; i++) {
			if (minT === undefined || inters[i].t1 <= inters[minT].t1) {
				minT = i;
			}
			if (maxT === undefined || inters[i].t1 >= inters[maxT].t1) {
				maxT = i;
			}
		}

		//decide, if path is clockwise (1) or counter clockwise (-1)
		if (startY < lineY && inters[minT].segment2 >= inters[maxT].segment2 || startY > lineY && inters[minT].segment2 <= inters[maxT].segment2) {
			//for path with only one segment compare t
			if (inters[minT].segment2 == inters[maxT].segment2) {
				if (startY < lineY && inters[minT].t2 >= inters[maxT].t2 || startY > lineY && inters[minT].t2 <= inters[maxT].t2) {
					dir = 1;
				}
			} else {
				dir = 1;
			}
		}

		return dir;
	};

	/**
	 * wrapper for RaphaelJS pathIntersection()
	 * with filter for redundant intersections caused by
	 * - self-intersection (path1 = path2)
	 * - intersections that lies exactly in path points (path1 != path2; use strict mode!)
	 *
	 * @param string path1
	 * @param string path2
	 * @param bool strict (true: also assume intersections as obolete that are close segment's starting / ending points; use only when path1 != path2!)
	 *
	 * @returns array validInters (filtered path intersections calculated by Raphael.pathIntersections())
	 */
	var getIntersections = function(path1, path2, strict) {
		var d = 0.1; //min. deviation to assume point as different from another
		var inters = Raphael.pathIntersection(path1, path2);
		var validInters = [];
		var valid = true;

		//iterate all other intersections
		for (var i = 0; i < inters.length; i++) {
			var p = inters[i];
			valid = true;

			//iterate all valid intersections and check if point already exists, if not push to valid intersections
			if (validInters.length > 0) {
				for (var j = 1; j < validInters.length; j++) {
					if((Math.abs(validInters[j].x - p.x) < d && Math.abs(validInters[j].y - p.y) < d)) {
						valid = false;
						break;
					}
				}
			}

			if (valid && strict) {
				if ((1 - p.t1 < d || p.t1 < d) && (1 - p.t2 < d || p.t2 < d)) {
					valid = false;
				}
			}

			if (valid) {
				validInters.push(inters[i]);
			}
		}

		return validInters;
	};

	/**
	 * collect the parts of the resulting path according to given rules for the type of boolean operation
	 * a part is characterized as a bunch of segments - first and last segment hosts a sub-path starting / ending point or intersection point
	 *
	 * @param string type (type of boolean operation)
	 * @param array path1Segs (path1 in segment representation)
	 * @param array path1Segs (path2 in segment representation)
	 *
	 * @returns array newParts (array of arrays holding segments)
	 */
	var buildNewPathParts = function(type, path1Segs, path2Segs) {
		var IOSituationChecked = false;
		var insideOtherPath; //temporary flag
		var partNeeded = false;
		var segCoords; //temporary array of coordinates of current segment
		var newPathPart = [];
		var newParts = [];

		/*
		Add-Part-to-new-Path-Rules:
			union:
			path1 - segment NOT inside path2
			path2 - segment NOT inside path1
			difference:
			path1 - segment NOT inside path2
			path2 - segment inside path1
			intersection:
			path1 - segment inside path2
			path2 - segment inside path1
		*/
		var rules = {
			union: {
				0: false,
				1: false
			},
			difference: {
				0: false,
				1: true
			},
			intersection: {
				0: true,
				1: true
			}
		};

		var paths = {
			0: {
				segs: path1Segs,
				nr: 1
			},
			1: {
				segs: path2Segs,
				nr: 2
			}
		};

		//iterate both paths and collect parts that are needed according to rules
		for (var p = 0; p <= 1; p++) {
			for (var s = 0; s < paths[p].segs.length; s++) {
				segCoords = paths[p].segs[s];

				if (segCoords.length === 0) {
					continue;
				}
				if (!IOSituationChecked) {
					insideOtherPath = isSegInsidePath(segCoords, pathSegsToStr(paths[p ^ 1].segs));
					IOSituationChecked = true;
					partNeeded = (rules[type][p] == insideOtherPath);
				}

				//if conditions are satisfied add current segment to new part
				if (partNeeded) {
					newPathPart.push(segCoords);
				}

				if (typeof segCoords.endPoint != "undefined") {
					if (partNeeded) {
						newPathPart.pathNr = paths[p].nr;
						newParts.push(newPathPart);
					}
					newPathPart = [];
					IOSituationChecked = false;
				}
			}
		}

		return newParts;
	};

	/**
	 * build indexes of the given path parts in order to simplify the process of putting parts together to a new path
	 *
	 * @param array parts
	 *
	 * @returns object (holding indexes and information about inverted parts)
	 */
	var buildPartIndexes = function(parts) {
		var startIndex = {};
		var endIndex = {};
		var inversions = {
			1: 0,
			2: 0
		}; //count inversions on parts formerly belonging to path with the particular number

		//iterate all parts of the new path and build indices of starting and ending points
		for (var p = 0; p < parts.length; p++) {

			//if starting point or ending point id already exists (and there are different) invert the part
			if (parts[p][0].startPoint != parts[p][parts[p].length - 1].endPoint) { //parts[p].pathNr == 2 &&
				if (typeof startIndex[parts[p][0].startPoint] != "undefined" || typeof endIndex[parts[p][parts[p].length - 1].endPoint] != "undefined") {
					//invert the segments
					invertPart(parts[p]);

					//count inversions
					inversions[parts[p].pathNr]++;
					parts[p].inverted = true;
				}
			}

			//save intersection id at starting point
			startIndex[parts[p][0].startPoint] = p;
			endIndex[parts[p][parts[p].length - 1].endPoint] = p;
		}

		return {
			inversions: inversions,
			startIndex: startIndex,
			endIndex: endIndex
		};
	};

	/**
	 * the final step: build a new path out of the given parts by putting together the appropriate starting end ending points
	 *
	 * @param string type (type of the boolean operation)
	 * @param array parts (see buildNewPathParts())
	 * @param object inversions (see buildPartIndexes())
	 * @param array startIndex (see buildPartIndexes())
	 *
	 * @returns array resultPath (segment representation of the operation's resulting path)
	 */
	var buildNewPath = function(type, parts, inversions, startIndex) {
		var newPath = [];

		//for union operation correct path directions where necessary
		if (type == "union") {
			//if inversions occured invert also other parts of the path (only where starting point = ending point)
			for (var p = 0; p < parts.length; p++) {
				if (inversions[parts[p].pathNr] > 0 && !parts[p].inverted && parts[p][0].startPoint == parts[p][parts[p].length - 1].endPoint) {
					invertPart(parts[p]);
				}
			}
		}

		//build new path as an array of (closed) sub-paths (segment representation)
		if (parts.length > 0) {
			var partsAdded = 0;
			var curPart = parts[0];
			var firstStartPoint = parts[0][0].startPoint;
			var endPointId;
			var subPath = [];
			var dirCheck = []; //starting position of subpaths marked for a direction check

			while (partsAdded < parts.length) {
				//for difference operation prepare correction of path directions where necessary
				if (type == "difference") {
					//if part was belonging to path 2 and starting point = ending point (means part was a subpath of path2 and completely inside path1)
					if (curPart.pathNr == 2 && curPart[0].startPoint == curPart[curPart.length - 1].endPoint) {
						dirCheck.push(newPath.length);
					}
				}

				subPath = subPath.concat(curPart);
				partsAdded++;
				endPointId = curPart[curPart.length - 1].endPoint;
				curPart.added = true;
				if (endPointId != firstStartPoint) { //path isn't closed yet
					curPart = parts[startIndex[endPointId]]; //new part to add is the one that has current ending point as starting point
				} else { //add subpath to new path and find part that hasn't been added yet to start a new sub-path
					newPath.push(subPath);
					subPath = [];

					for (var p = 1; p < parts.length; p++) {
						if (!parts[p].added) {
							curPart = parts[p];
							firstStartPoint = parts[p][0].startPoint;
							break;
						}
					}
				}
			}
		}

		//for difference operation correct path direction (by inverting sub-paths) where necessary
		if (type == "difference") {
			for (var i = 0; i < dirCheck.length; i++) {
				//inside which subpath is the subpath that has to be checked
				for (var o = 0; o < newPath.length; o++) {
					if (dirCheck[i] == o) {
						continue;
					}
					if (isSegInsidePath(newPath[dirCheck[i]][0], pathSegsToStr(newPath[o]))) {
						var pathDirOut = getPathDirection(newPath[o]);
						var pathDirIn = getPathDirection(newPath[dirCheck[i]]);

						//if both subpaths have the same direction invert the inner path
						if (pathDirIn == pathDirOut) {
							invertPart(newPath[dirCheck[i]]);
						}
					}
				}
			}
		}

		//flatten new path
		var resultPath = [];
		for (var i = 0; i < newPath.length; i++) {
			resultPath = resultPath.concat(newPath[i]);
		}

		return resultPath;
	};

	/**
	 * execute the bool operation
	 *
	 * @param string type (name of the boolean operation)
	 * @param array path1Segs (segment representation of path1)
	 * @param array path2Segs (segment representation of path2)
	 *
	 * @return array newPath (segment representation of the resulting path)
	 */
	var execBO = function(type, path1Segs, path2Segs) {
		path1Segs = JSON.parse(JSON.stringify(path1Segs));
		path2Segs = JSON.parse(JSON.stringify(path2Segs));

		//mark the starting and ending points of the subpaths
		markSubpathEndings(path1Segs, path2Segs);

		//get intersections of both paths (use strict mode)
		var inters = getIntersections(pathSegsToStr(path1Segs), pathSegsToStr(path2Segs), true);

		//if any insert intersections into paths
		if (inters.length > 0) {
			insertIntersectionPoints(path1Segs, 1, inters);
			insertIntersectionPoints(path2Segs, 2, inters);
		}

		var newParts = buildNewPathParts(type, path1Segs, path2Segs);

		var indexes = buildPartIndexes(newParts);

		return buildNewPath(type, newParts, indexes.inversions, indexes.startIndex);
	};

	/**
	 * prepare a RaphaelJS element for boolean operation
	 *
	 * @param object el (RaphaelJS element)
	 *
	 * @returns array pathSegs (given element in path segment representation)
	 */
	var prepare = function(el) {
		//get path array (convert element to path)
		var pathArr = (el.type == "path") ? el.attr("path") : toPath(el);

		//get rid of transformations
		pathArr = Raphael.transformPath(pathArr, el.matrix.toTransformString());

		//convert to curves
		pathArr = Raphael.path2curve(pathArr);

		//convert RaphaelJS' internal path representation to segment representation (of bezier curves) for better handling
		return pathArrToSegs(pathArr);
	};

	/**
	 * perform a union of the two given paths
	 *
	 * @param object el1 (RaphaelJS element)
	 * @param object el2 (RaphaelJS element)
	 *
	 * @returns string (path string)
	 */
	var union = function(el1, el2) {
		var pathA = prepare(el1),
			pathB = prepare(el2);
		return pathSegsToStr(execBO("union", pathA, pathB));
	};

	/**
	 * perform a difference of the two given paths
	 *
	 * @param object el1 (RaphaelJS element)
	 * @param object el2 (RaphaelJS element)
	 *
	 * @returns string (path string)
	 */
	var difference = function(el1, el2) {
		var pathA = prepare(el1),
			pathB = prepare(el2);
		return pathSegsToStr(execBO("difference", pathA, pathB));
	};

	/**
	 * perform an intersection of the two given paths
	 *
	 * @param object el1 (RaphaelJS element)
	 * @param object el2 (RaphaelJS element)
	 *
	 * @returns string (path string)
	 */
	var intersection = function(el1, el2) {
		var pathA = prepare(el1),
			pathB = prepare(el2);
		return pathSegsToStr(execBO("intersection", pathA, pathB));
	};

	/**
	 * perform an exclusion of the two given paths -> A Exclusion B = (A Union B) Difference (A Intersection B)
	 *
	 * @param object el1 (RaphaelJS element)
	 * @param object el2 (RaphaelJS element)
	 *
	 * @returns string (path string)
	 */
	var exclusion = function(el1, el2) {
		var pathA = prepare(el1),
			pathB = prepare(el2);
		return pathSegsToStr(execBO("difference", execBO("union", pathA, pathB), execBO("intersection", pathA, pathB)));
	};

	//add public methods to Raphael
	Raphael.fn.toPath = toPath;

	Raphael.fn.union = union;
	Raphael.fn.difference = difference;
	Raphael.fn.intersection = intersection;
	Raphael.fn.exclusion = exclusion;
})();
