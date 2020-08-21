remark.macros.scale = function (percentage) {
	var url = this;
	return '<img src="' + url + '" style="width: ' + percentage + '" />';
};  
 		
var slideshow = remark.create({
	highlightLines: true,
	ratio: '16:9',
	countIncrementalSlides: false		
});