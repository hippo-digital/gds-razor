/* eslint-disable no-console */
"use strict";

const gulp = require("gulp"),
    rimraf = require("rimraf"),
    sass = require("gulp-sass"),
    connect = require('gulp-connect'),
    concat = require('gulp-concat');

let paths = {
    src: "AssetSrc/",
    dist: "wwwroot/",
    temp: ".temp/"
};

paths.assetsDest = paths.dist + "assets/";
paths.css = paths.temp + "css/**/*.css";

paths.scss = paths.src + "scss/**/*.scss";
paths.cssDest = paths.assetsDest + "css/";

paths.images = paths.src  + "/images/**";
paths.imagesDest = paths.assetsDest + "images/";

paths.jsSrc = paths.src + "js/**/*.js";
paths.js = ["./node_modules/govuk-frontend/govuk/all.js", paths.jsSrc];
paths.jsDest = paths.dist + "/js/";

gulp.task('assets', function () {
    return gulp.src(['./node_modules/govuk-frontend/govuk/assets/**/*'])
        .pipe(gulp.dest(paths.assetsDest));
});

gulp.task('images', function () {
    return gulp.src([paths.images]).pipe(gulp.dest(paths.imagesDest));
});

gulp.task("js", function () {
    return gulp.src(paths.js, { sourcemaps: true })
        .pipe(concat("main.js"))
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task("sass", function () {
    return gulp.src(paths.scss)
        .pipe(sass({
            includePaths: 'node_modules'
        }))
        .pipe(gulp.dest(paths.cssDest))
        .pipe(connect.reload());
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.css, cb);
});

gulp.task("sass:watch", () => gulp.watch(paths.scss, gulp.series("sass")));
gulp.task("js:watch", () => gulp.watch(paths.jsSrc, gulp.series("js")));

gulp.task("dev",
    gulp.series(
        "clean:css",
        "assets",
        "sass",
        "images",
        "js",
        gulp.parallel(
            "sass:watch",
            "js:watch")
    )
);


gulp.task("prod",
    gulp.series(
        "clean:css",
        "assets",
        "sass",
        "images",
        "js"
    )
);
