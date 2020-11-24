#!/bin/bash

echo "Converting Doxygen XML to Markdown"

mkdir docs
cp doxygen/mkdocs.yml docs/mkdocs.yml
./doxygen/doxybook2 --input xml/ --output docs/ --config doxygen/doxybookcfg.json
rm -r docs/Files
rm -r docs/Pages
cp doxygen/favicon.ico docs/img
cp doxygen/index.md docs/index.md
echo "Done"